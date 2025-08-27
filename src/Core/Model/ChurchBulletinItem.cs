﻿using System.Security.Policy;

namespace ProgrammingWithPalermo.ChurchBulletin.Core.Model;

public class ChurchBulletinItem : EntityBase<ChurchBulletinItem>
{
    public string? Name { get; set; }
    public string? Place { get; set; }
    public DateTime Date { get; set; }
    public override Guid Id { get; set; }
}