using System;
using System.Collections.Generic;

namespace SZÓKITALÁLÓ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ///DATA
            string A_SZO = Console.ReadLine();/// a gondolt szó
            char[] BETU_ARRAY = A_SZO.ToCharArray();/// itt betűkké változik a szó egy betű array-já
            List<char> BETU_LISTA = new List<char>();/// ez a betűk listája
            foreach (char BETU in BETU_ARRAY)///itt az összes betűt bepakoljuk egy betű listába
            {


                BETU_LISTA.Add(BETU);///a lista hozzáadási folyamat(igazábol ez bonylítja de legalább elmondhatjuk ez is van benne)

            }
            string BETUK_SZAMANA_STRING = Convert.ToString(BETU_LISTA.Count);///betűlista tartalmának száma átváltása string-be
            Console.WriteLine("Gondoltam egy szóra ami " + BETUK_SZAMANA_STRING + " betűből áll");
            int HIBA_LEHET = 10;///hibalehetőségek
            List<char> BETU_NINCS = new List<char>();///azok a betűk listálya amikre hibásan tippeltünk
            List<char> BETU_VAN = new List<char>();///azok betűk listálya amiket sikerasen tippeltünk
            Dictionary<int, char> BETU_HELYE = new Dictionary<int, char>();///a sikeresen tippelt betűk listálya helyileg
            int x = 0;///a vonalak és betűhelyeknél van hasznáva a HELYEK tartományban
            int BETUKETTO = 0;///a több egytipusú betűk számának tároló értéke
            bool ERTEKELO = false;///ennek iagz vagy hamis értéke befolyásolja a win/lose arányt
            ///DATA vége

            ///a helyek tartománya
            foreach (char ELEM in BETU_LISTA)
            {
                x++;
                BETU_HELYE.Add(x, '_');
            }
            ///a helyek tartománya vége

            ///MAIN RÉSZ
            for (int z = 0; z < 100; z++)///ez direct 100 csak azert van hogy a feltételsorozat ujra és ujra megismétlődjön
            {
                if (HIBA_LEHET == 0)///ha a hibalehetőségek 0 akkor meghaltál
                {
                    Console.WriteLine("Sajnálom, vesztettél.");
                    break;
                }
                else if (BETU_LISTA.Count == 0)///ha a betűk a listábol mind elfogynak az az nem lesz tobb keresendő betű akkor nyertél
                {
                    Console.WriteLine("Nyertél!");
                    Console.Write("A kitalált szó: ");
                    for (int i = 0; i < BETU_HELYE.Count; i++)
                    {

                        Console.Write(BETU_HELYE[i+1]);
                    }
                    break;
                }

                x = 0;
                while (x <= BETU_ARRAY.Length - 1)
                {
                    x++;
                    Console.Write(BETU_HELYE[x]);


                }
                Console.WriteLine(" Adj meg egy betűt és próblákozz,hogy kitatáld a szót");
                char BEMENET = Convert.ToChar(Console.ReadLine());



                ///Döntő tartomány
                ///ez addig ismétlődik még nem talál betut ,ha van.
                for (int i = 0; i < BETU_LISTA.Count; i++)///ez addig ismétlődik még van a listában betű,de feladata,hogy megkeresse a listában lévő betűket és egyeztesse a beneti betűvel
                {

                    
                    if (BEMENET == BETU_LISTA[i])///ha a beneti betű megegyezik valamelyik listában lévő betűvel akkor az ERTEKELO igaz lesz 
                    {
                        ERTEKELO = true;///a win/lose értékelője
                        

                            

                    }
                    
                }
                ///Döntő tartomány vége
                
                ///Értékelő tartomány
                if (ERTEKELO == true)///ha talált betűt
                {
                        BETUKETTO = 0;///ha egy betűböl több van akkor ez az érték ami ennek számát mondja meg és jelenleg itt resetelődik, gyakorlatileg nincs értelme de bisztositék anomáliák esetén
                        
                        for (int VALT_I = 0; VALT_I < BETU_ARRAY.Length; VALT_I++)///anyiszor ellenőriz amelyi betűből áll a szó
                        {   
                            if (BEMENET == BETU_ARRAY[VALT_I])///itt adja meg hogy menyi egy tipusú betű van és továbbá itt ad helyet a BETU_HELYE listában ami alapján a vonalak megfelő poziciójában helyezi el
                            {
                                BETUKETTO++;
                                BETU_HELYE[VALT_I + 1] = BEMENET;

                            }
                            

                        }
                        while (BETUKETTO > 0)///itt anyiszor törli ki a betűt amenyiszer szerepel a BETU_LISTA - ban
                        {   

                                BETU_LISTA.Remove(BEMENET);
                                BETUKETTO--;
                                
                     

                        }
                        Console.WriteLine("Talált [ " + BEMENET + " ] betű van benne");
                        BETU_VAN.Add(BEMENET);
                }

                
                else if (ERTEKELO != true)///ha elvéted és hibázol... egyszer eljő a halál órája :D
                {
                    HIBA_LEHET--;
                    BETU_NINCS.Add(BEMENET);
                    Console.WriteLine("Nem talált [ " + HIBA_LEHET + " ] próbálkozásod van");
                }
                ERTEKELO = false;///mivel az ERTEKELO-t az infinity loop elkerülése miatt resetelni kell, ha persze igaz volt.
                ///Értékelő tartomány vége
                
                ///HELP a felhasználónak tartomány
                foreach (char VAN in BETU_VAN)
                {

                    Console.Write(VAN + " ");
                }
                Console.WriteLine(" ] Kitalált betűk");
                
                foreach (char NINCS in BETU_NINCS)
                {

                    Console.Write(NINCS + " ");
                }
                Console.WriteLine(" ] Nincs benne");
            }   ///HELP a felhasználónak tartomány vége
            ///MAIN RÉSZ VÉGE
        }///HIBÁK:   a nagy és a kicsi betűk között is külömbséget tesz
    }
     
}


