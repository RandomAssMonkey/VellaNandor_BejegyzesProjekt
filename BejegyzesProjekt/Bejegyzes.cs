﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejegyzesProjekt
{
    class Bejegyzes
    {
            public string Szerzo { get; }
            public string Tartalom { get; set; }
            public int Likeok { get; private set; }
            public DateTime Letrejott { get; }
            public DateTime Szerkesztve { get; private set; }

            public Bejegyzes(string szerzo, string tartalom)
            {
                this.Szerzo = szerzo;
                this.Tartalom = tartalom;
                this.Likeok = 0;
                this.Letrejott = DateTime.Now;
                this.Szerkesztve = DateTime.Now;
            }

            public void Like()
            {
                this.Likeok++;
            }

            public override string ToString()
            {
            string szerkesztettSzoveg = this.Szerkesztve == this.Letrejott ? "" : $"Szerkesztve: {this.Szerkesztve}";
            return $"{this.Szerzo} - {this.Likeok} - {this.Letrejott} {szerkesztettSzoveg}: {this.Tartalom}";
            }
        }
    }
