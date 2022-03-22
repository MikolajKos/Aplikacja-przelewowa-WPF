using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace peselWPF
{
    class Pesel
    {

        private string numerPesel;

        public string Plec
        {
            get
            {
                char cyfraPlec = numerPesel[9];
                int liczbaPlec = int.Parse(cyfraPlec.ToString());
                if (liczbaPlec % 2 == 0)
                    return "Kobieta";
                else
                    return "Mężczyzna";
            }

        }

        public string Data
        {
            get
            {
                string rok = numerPesel[0].ToString() + numerPesel[1].ToString();
                string wiek = numerPesel[2].ToString();
                string miesiac = numerPesel[3].ToString();
                string dzien = numerPesel[4].ToString() + numerPesel[5].ToString();

                int miesiacInt = int.Parse(miesiac);
                int dzienInt = int.Parse(dzien);
                int wiekInt = int.Parse(wiek);

                if (wiekInt == 9 || wiekInt == 1 || wiekInt == 3 || wiekInt == 5  || wiekInt == 7)
                {
                    miesiac = "1" + miesiac;
                }
                else
                {
                    miesiac = "0" + miesiac;
                }

                    switch (wiek)
                {
                    case "8" or "9":
                        return wiek = dzien + "/" + miesiac + "/" + "18" + rok;
                        break;

                    case "0" or "1":
                        return wiek = dzien + "/" + miesiac + "/" + "19" + rok;
                        break;

                    case "2" or "3":
                        return wiek = dzien + "/" + miesiac + "/" + "20" + rok;
                        break;

                    case "4" or "5":
                        return wiek = dzien + "/" + miesiac + "/" + "21" + rok;
                        break;

                    case "6" or "7":
                        return wiek = dzien + "/" + miesiac + "/" + "22" + rok;
                        break;

                    default:
                        return "Błąd.";
                        break;
                }


            }
        }

        public Pesel(string numer)
        {
            numerPesel = numer;
            WalidacjaNumeruPesel();
        }

        private void WalidacjaPoprawnosciZnakow()
        {

            for (int i = 0; i < numerPesel.Length; i++)
            {
                if (numerPesel[i] < '0' || numerPesel[i] > '9')
                    throw new Exception("Ciąg musi składac się tylko z cyfr.");
            }
        }

        private void WalidacjaCyfryKontrolnej()
        {

        }

        private void WalidacjaMiesiaca()
        {

            if(numerPesel[2] == 3 && numerPesel[3] > 2)
            {
                throw new Exception("Podano zbyt wysoką liczbę miesiąca.");
            }

            if(numerPesel[3] == 0)
            {

                if(numerPesel[2] != 9 || numerPesel[2] != 1 || numerPesel[2] != 3 || numerPesel[2] != 5 || numerPesel[2] != 0)
                {
                    throw new Exception("Podany pesel nie istnieje (nieprawidłowy mieisąc).");
                }

            }
        }

        private void WalidacjaDnia()
        {
        }

        private void WalidacjaNumeruPesel()
        {
            WalidacjaIloscZnakow();
            WalidacjaPoprawnosciZnakow();
            WalidacjaDnia();
            WalidacjaMiesiaca();
            WalidacjaCyfryKontrolnej();
            
        }

        private void WalidacjaIloscZnakow()
        {
            if (numerPesel.Length != 11)
                throw new Exception("Błędna ilość znaków  w numerze.");
        }

    }
}
