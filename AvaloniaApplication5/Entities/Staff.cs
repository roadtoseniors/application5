using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AvaloniaApplication5.Entities;

public partial class Staff
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public int? Division { get; set; }

    public int? Department { get; set; }
    [JsonIgnore]
    public int? StaffId { get; set; }

    public virtual Department? DepartmentNavigation { get; set; }

    public virtual Division? DivisionNavigation { get; set; }
}
