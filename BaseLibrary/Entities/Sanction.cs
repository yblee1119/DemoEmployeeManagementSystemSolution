using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Sanction : OtherBaseEntity
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Punishment { get; set; } = string.Empty;  //처벌
        [Required]
        public DateTime PunishmentDate { get; set; } // 처벌일자

        // Many to one relationship with Vacation Type
        public SanctionType? SanctionType { get; set; } // 제재타입  처벌타입
    }
}
