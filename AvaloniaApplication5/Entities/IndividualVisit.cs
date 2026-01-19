using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AvaloniaApplication5.Entities;

public partial class IndividualVisit
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public string? EMail { get; set; }

    public string? DateOfBirthday { get; set; }

    public string? Passport { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? DatePurpose { get; set; }
    [JsonIgnore]
    public int? StaffId { get; set; }

    public virtual StaffCode? Staff { get; set; }
}
