﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteDeQuadrinhos.Models
{
    public class QuadrinhoModel
    {
        [Key()]
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? TagPrincipal { get; set; }
        public byte[] Capitulo { get; set; }
        public byte[] Capa { get; set; }
        [ForeignKey("UsuarioModel")]
        public Guid UsuarioId { get; set; }
        public virtual UsuarioModel usuarioModel { get; set; }
    }
}
