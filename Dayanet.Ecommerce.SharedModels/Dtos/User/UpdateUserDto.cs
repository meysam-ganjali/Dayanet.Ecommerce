﻿using Dayanet.Ecommerce.SharedModels.Dtos.Role;

namespace Dayanet.Ecommerce.SharedModels.Dtos.User;

public class UpdateUserDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string CellPhone { get; set; }
    public string? Email { get; set; }
    public DateTime UpdateedDate { get; set; }
}