using AutoMapper;
using BarbershopManager.Communication.Requests.Users;
using BarbershopManager.Communication.Responses.Users;
using BarbershopManager.Domain;
using BarbershopManager.Domain.Entities;
using BarbershopManager.Domain.Security.Cryptography;
using BarbershopManager.Domain.Security.Token;
using BarbershopManager.Domain.UsersRepository;
using BarbershopManager.Exception.ExceptionBase;

namespace BarbershopManager.Application.UseCases.Users.Register;
public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReadOnlyUserRepository _readOnlyUserRepository;
    private readonly IWriteOnlyUserRepository _writeOnlyUserRepository;
    private readonly IEncryptor _encryptor;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

	public RegisterUserUseCase(IMapper mapper, IUnitOfWork unitOfWork, IReadOnlyUserRepository readOnlyUserRepository, IWriteOnlyUserRepository writeOnlyUserRepository, IEncryptor encryptor, IJwtTokenGenerator jwtTokenGenerator )
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _readOnlyUserRepository = readOnlyUserRepository;
        _writeOnlyUserRepository = writeOnlyUserRepository;
        _encryptor = encryptor;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
	{
		await Validate(request);

        var user = _mapper.Map<User>(request);
        user.Password = _encryptor.Encrypte(request.Password);
        user.UserIdentifier = Guid.NewGuid();
        user.DateOfRegister = DateTime.Today;


        await _writeOnlyUserRepository.Add(user);

        await _unitOfWork.Commit();

        return new ResponseRegisteredUserJson
        {
            Name = request.Name,
            Token = _jwtTokenGenerator.GenerateToken(user)
        };

	}
    private async Task Validate(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        var existEmail = await _readOnlyUserRepository.ExistAnyUserWithThisEmail(request.Email);

		if (existEmail == true)
		{
			var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

			throw new ErrorOnValidationException(errorMessages);
		}

		if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
      
     
	}
}
