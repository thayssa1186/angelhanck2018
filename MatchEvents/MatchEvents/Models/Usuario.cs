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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Nome { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(11)]
        public string Telefone { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string Sexo { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Idade { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(8)]
        public string Senha { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime DataCriacao { get; set; }
    }
}
