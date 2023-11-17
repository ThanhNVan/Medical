using FptUni.BpHospital.Common;
using ShareLibrary.EntityProviders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FptUni.BpHostpital.HR.Utils;

[Table(nameof(ContactPerson))]
public class ContactPerson : BaseEntity
{
	#region [ Properties ]
	[Required]
	[DataType(DataType.Text)]
	public string Firstname { get; set; }
	
	[Required]
	[DataType(DataType.Text)]
	public string Lastname { get; set; }

	[NotMapped]
	public string Fullname => Firstname + " " + Lastname;

	[Required]
	[DataType(DataType.PhoneNumber)]
	public string PhoneNumber1 { get; set; }

	[DataType(DataType.PhoneNumber)]
	public string? PhoneNumber2 { get; set; }

	[Required]
	public RelationshipWithUser RelationshipWithUser { get; set; }

	[DataType(DataType.EmailAddress)]
	public string EmailAddress { get; set; }

	[Required]
    [DataType(DataType.Text)]
    public string Address { get; set; }

	[Required]
	[DataType(DataType.Text)]
    public string Ward { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string City { get; set; }
	
	[Required]
    [DataType(DataType.Text)]
    public string State { get; set; }
	
	[Required]
    [DataType(DataType.Text)]
    public string Country { get; set; }
	
	[Required]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; }
	#endregion

	#region [ Properties - FK]
	[Required]
    [DataType(DataType.Text)]
	public string UserId { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(UserId))]
    [InverseProperty("ContactPersons")]
    public User? User { get; set; }
    #endregion
}
