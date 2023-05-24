using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    public class Partida
    {
        //Atributs i propietats
        public int Id { get; set; }
        public int BotVida { get; set; }
        public int UsuariVida { get; set; }
        public string EstatPartida { get; set; }
        public Bot Bot { get; set; }
        public Usuari Usuari { get; set; }
        //Constructors
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
