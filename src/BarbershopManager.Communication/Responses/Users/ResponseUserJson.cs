﻿namespace BarbershopManager.Communication.Responses.Users;
public class ResponseUserJson
{
	public string Name { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public DateTime DateOfRegister { get; set; }
}
