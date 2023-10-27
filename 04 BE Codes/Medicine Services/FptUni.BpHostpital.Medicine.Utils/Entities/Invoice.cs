using System.ComponentModel.DataAnnotations.Schema;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHostpital.Medicine.Utils;

[Table(nameof(Invoice))]
public class Invoice : BaseEntity
{
}
