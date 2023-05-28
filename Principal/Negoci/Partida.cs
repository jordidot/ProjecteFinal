using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    /// <summary>
    /// Classe Partida
    /// </summary>
    public class Partida
    {
        //Atributs i propietats
        /// <summary>
        /// Id partida
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Vida del bot partida
        /// </summary>
        public int BotVida { get; set; }
        /// <summary>
        /// Vida Usuari Partida
        /// </summary>
        public int UsuariVida { get; set; }
        /// <summary>
        /// Resultat de la partida
        /// </summary>
        public string EstatPartida { get; set; }
        /// <summary>
        /// Bot de partida
        /// </summary>
        public Bot Bot { get; set; }
        /// <summary>
        /// Usuari logejat
        /// </summary>
        public Usuari Usuari { get; set; }
        //Constructors
        /// <summary>
        /// Constructor Partida
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bot"></param>
        /// <param name="botVida"></param>
        /// <param name="usuari"></param>
        /// <param name="usuariVida"></param>
        /// <param name="estatPartida"></param>
        public Partida(int id, Bot bot, int botVida,Usuari usuari, int usuariVida, string estatPartida)
        {
            this.Id = id;
            this.Bot = bot;
            this.BotVida = botVida;
            this.Usuari = usuari;
            this.UsuariVida = usuariVida;
            this.EstatPartida = estatPartida;
        }
    }
}
