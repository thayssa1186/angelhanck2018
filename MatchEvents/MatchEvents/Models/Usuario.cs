namespace MatchEvents.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Nome { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(11)]
        [RegularExpression(@"^[1-9]{2}[2-9][0-9]{7,8}$", ErrorMessage = "Digite o telefone celular com o DDD")]
        public string Telefone { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(1)]
        public string Sexo { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(@"^[0-9]{2}$", ErrorMessage = "Digite a idade corretamente")]
        public int Idade { get; set; }

        [StringLength(255)]
        public string Bairro { get; set; }

        [StringLength(255)]
        public string Cidade { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(8)]
        public string Senha { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DataCriacao { get; set; }
    }
}
