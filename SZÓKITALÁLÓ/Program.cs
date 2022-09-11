using System;
using System.Collections.Generic;
using System.Linq;

namespace SZÓKITALÁLÓ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region A bekérés tipusának bekérése:
            string BEMENETI_SZO;
            Console.WriteLine("Manuális vagy autómatikus bekérést szeretne (M/A)");
            string AB = Console.ReadLine();
            #endregion
            #region A bekérési tipus kiértékelése
            if (AB.ToUpper() == "M")
            {
                Console.WriteLine("Adja meg manuálisan a szót");
                BEMENETI_SZO = Console.ReadLine() + " ";
            }
            else
            {
                string AA = System.IO.Path.GetDirectoryName(typeof(Program).Assembly.Location);
                var random = new Random();///a random fügvény
                string[] SZAVAK = System.IO.File.ReadAllLines(AA + "\\SZAVAK.txt");/// a gondolt szavak txt file bekérése és SZAVAK arrayá alakítása
                List<string> SZAVAKList = new List<string>();///a szavak listálya
                foreach (string SZO in SZAVAK)///a szavak listába helyezése
                {
                    SZAVAKList.Add(SZO);

                }
                int RANDOM = random.Next(SZAVAK.Length);///egy random szám kitalálása ami max anyi lehet ahány sor van a txt file ban
                BEMENETI_SZO = SZAVAKList[RANDOM] + " ";///kiválasztunk egy elemet a SZVAKlist listából a random szám használatával
            }
            #endregion
            #region A dupla betűk és további változó adatai
            List<string> DUPLA_BETUK_LISTAJA = new List<string>(8);//dupla betűk listája
            DUPLA_BETUK_LISTAJA.Add("cs");
       
            DUPLA_BETUK_LISTAJA.Add("dz");
        
            DUPLA_BETUK_LISTAJA.Add("gy");
        
            DUPLA_BETUK_LISTAJA.Add("ly");
      
            DUPLA_BETUK_LISTAJA.Add("ny");
            
            DUPLA_BETUK_LISTAJA.Add("sz");
      
            DUPLA_BETUK_LISTAJA.Add("ty");
         
            DUPLA_BETUK_LISTAJA.Add("zs");
            
            int DUPLA_BETUK_SZAMA = 0;//dupla betűk száma a szóban
            int SINGLE_BETUK_SZAMA = 0;//single betűk száma a szóban
            int HIBA_LEHET = 10;//hibalehetőségek száma
            bool VAN_DUPLA_BETU;
            bool VOLT_DUPLA_BETU = false;
            bool TALALAT = false;
            bool VAN_ELENORZO = false;
            bool NINCS_ELLENORZO = false;
            //Console.WriteLine(BEMENETI_SZO);
            //Console.WriteLine(BEMENETI_SZO.Length);
            string BEMENETI_BETU;//bementi betű
            string VALT_II;
            string VALT_III;
            string[] BETUK_HELYE = new string[BEMENETI_SZO.Length - 1];
            string[] BETUK_ARRAY = new string[BEMENETI_SZO.Length - 1];
            List<string> BETU_VAN = new List<string>();
            List<string> BETU_NINCS = new List<string>();
            #endregion
            #region A szó elemzése és a dupla és single betűk helyének lekérése
            for (int i = 0; i < BEMENETI_SZO.Length - 1; i++)//addig elemzi a szót amenyi single elemből áll a szó
                {
                    VALT_II = Convert.ToString(BEMENETI_SZO[i]) + Convert.ToString(BEMENETI_SZO[i + 1]);// a dupla betűk érdekéban duplán ellenőrzi az indexeket így megállapíthatók a pontos poziciók
                    //Console.WriteLine("TEST " + i);
                    VAN_DUPLA_BETU = false;// itt resetelődik a dupla betű érzékelő ami a single betűk érzékelését tiltja le
                    for (int x = 0; x < 7; x++)// a listában lévő dupla betűket elemzi ,hogy vannak e vayg nincsenek a szó megadott dupla index pozicióján
                    {

                        
                        //Console.WriteLine(VALT_II);
                        //Console.WriteLine("TEST2 " + x);

                            if (VALT_II.ToLower() == DUPLA_BETUK_LISTAJA[x])//elemzi hogy van e dupla betű
                            {
                                BETUK_HELYE[i] = "--";//egy dupla betű helyet ad
                                BETUK_ARRAY[i] = VALT_II;//a dupla betű pontos tipusát is megadja 
                                DUPLA_BETUK_SZAMA++;//a dupla betűk számát módosítja
                                VAN_DUPLA_BETU = true;//ha van dupla betű akkor ez engedélyez egy számítást
                                //Console.WriteLine("TESTDUPLA " + x);
                            }



                    }
                    if (VAN_DUPLA_BETU == false)//ha nincs dupla betű akkor single betű lesz
                    {
                        if (VOLT_DUPLA_BETU == true)//ha volt már dupla betű az előző folyamatban akkor ez true és más számítást eredményez
                        {
                            VOLT_DUPLA_BETU = false;//ha volt dupla betű az előző folyamatban akkor most nem ad hozzá semmilyen betűt viszont így egy ! null ! értéket eredményez 
                            
                        }
                        else//ha nem volt dupal betű akkor egy single betűt ad hozzá 
                        {
                            SINGLE_BETUK_SZAMA++;
                            BETUK_HELYE[i] = "_";
                            BETUK_ARRAY[i] = Convert.ToString(VALT_II[0]);//deee
                            //Console.WriteLine("TESTSINGLE " + VALT_II);
                        }
                        
                    }
                    if (VAN_DUPLA_BETU == true)//itt történik a folyamat dupla betűvel való megbéjegzése ,ha volt dupla betű
                    {
                        VOLT_DUPLA_BETU = true;
                    }

                }   
                #endregion
                //Console.WriteLine(DUPLA_BETUK_SZAMA);
                //Console.WriteLine(SINGLE_BETUK_SZAMA);
                int OSSZES_BETU_SZAMA = DUPLA_BETUK_SZAMA + SINGLE_BETUK_SZAMA;// a betűk számának összege ami a win/lose kiértékelésért felel
                // Console.WriteLine(OSSZES_BETU_SZAMA);
                /*
                foreach (string item in BETUK_ARRAY)
                {
                    Console.Write(item);
                }
                */
            #region A MAIN rész ahol maga a játék történik
            while (OSSZES_BETU_SZAMA > 0)
                {
                    foreach (string item in BETUK_HELYE)
                    {
                        Console.Write(item);
                    }
                    TALALAT = false;
                    Console.WriteLine(" ] Betűk helyei");
                    foreach (string item in BETU_VAN)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine(" ] Betűket már kitaláltad");
                    foreach (string item in BETU_NINCS)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine(" ] Betűket már kitaláltad ,de nincsenek a szóban");
                    Console.WriteLine("ADJA MEG A TIPPJÉT");
                    BEMENETI_BETU = Console.ReadLine();
                    VAN_ELENORZO = false;
                    if (BEMENETI_BETU.Length > 1)
                    {
                        for (int i = 0; i < BEMENETI_SZO.Length - 1; i++)
                        {
                            if (BETUK_ARRAY[i] != null)
                            {
                                VALT_III = Convert.ToString(BETUK_ARRAY[i]).ToLower();
                                if (VALT_III == BEMENETI_BETU.ToLower())
                                {
                                    if (BETU_VAN.Count == 0)
                                    {
                                        OSSZES_BETU_SZAMA--;
                                        BETUK_HELYE[i] = BETUK_ARRAY[i];
                                        TALALAT = true;
                                    }
                                    else
                                    {
                                        
                                        for (int s = 0; s < BETU_VAN.Count; s++)
                                        {
                                            if (BETU_VAN[s] == BEMENETI_BETU.ToLower())
                                            {
                                                VAN_ELENORZO = true;
                                            }
                                        }
                                        if (VAN_ELENORZO == true)
                                        {
                                            
                                        }
                                        else
                                        {
                                            OSSZES_BETU_SZAMA--;
                                            BETUK_HELYE[i] = BETUK_ARRAY[i];
                                            TALALAT = true;
                                        }
                                    }

                                }
                            }
       
                        }
                        if (VAN_ELENORZO == true)
                        {
                            Console.WriteLine(BEMENETI_BETU + " ] már volt");
                        }
                        if (TALALAT == true)
                        {
                            Console.WriteLine("TALÁLT [ " + BEMENETI_BETU + " ] betű van benen.");
                            BETU_VAN.Add(BEMENETI_BETU.ToLower());
                        }
                    }
                    else
                    {
                        for (int i = 0; i < BEMENETI_SZO.Length - 1; i++)
                        {
                            if (BETUK_ARRAY[i] != null)
                            {
                                VALT_III = Convert.ToString(BETUK_ARRAY[i]).ToLower();
                                if (VALT_III == BEMENETI_BETU.ToLower())
                                {
                                    
                                        if (BETU_VAN.Count == 0)
                                        {
                                            OSSZES_BETU_SZAMA--;
                                            BETUK_HELYE[i] = BETUK_ARRAY[i];
                                            TALALAT = true;
                                        }
                                        else
                                        {
                                            
                                            
                                            for (int s = 0; s < BETU_VAN.Count; s++)
                                            {
                                                if (BETU_VAN[s] == BEMENETI_BETU.ToLower())
                                                {
                                                    
                                                    VAN_ELENORZO = true;
                                                }
                                            }
                                            if (VAN_ELENORZO == true)
                                            {
                                                
                                                
                                            }
                                            else
                                            {
                                                OSSZES_BETU_SZAMA--;
                                                BETUK_HELYE[i] = BETUK_ARRAY[i];
                                                TALALAT = true;
                                            }
                                        }
                                  
                                }
                            }
                        }
                        if (VAN_ELENORZO == true)
                        {
                            Console.WriteLine(BEMENETI_BETU + " ] már volt");

                        }
                    if (VAN_ELENORZO == false)
                    {
                        if (TALALAT == true)
                        {
                            Console.WriteLine("TALÁLT [ " + BEMENETI_BETU + " ] betű van benen.");
                            BETU_VAN.Add(BEMENETI_BETU.ToLower());
                        }
                    }

                    }
                    NINCS_ELLENORZO = false;
                    if (VAN_ELENORZO == false)
                    {
                        if (TALALAT == false)
                        {
                            if (BETU_NINCS.Count > 0)
                            {
                                
                                for (int i = 0; i < BETU_NINCS.Count; i++)
                                {
                                    if (BETU_NINCS[i] == BEMENETI_BETU.ToLower())
                                    {
                                        NINCS_ELLENORZO = true;
                                    }

                                }
                                if (NINCS_ELLENORZO == true)
                                {
                                    Console.WriteLine(BEMENETI_BETU + " ] már volt és nem volt jó");
                                }
                                else
                                {
                                    HIBA_LEHET--;
                                    Console.WriteLine("NEM TALÁLT [ " + BEMENETI_BETU + " ] betű nincs benne.");
                                    Console.WriteLine("MÉG [ " + HIBA_LEHET + " ] PRÓBÁLKOZÁSOD VAN");
                                    BETU_NINCS.Add(BEMENETI_BETU.ToLower());
                                }
                            }
                            else
                            {
                                HIBA_LEHET--;
                                Console.WriteLine("NEM TALÁLT [ " + BEMENETI_BETU + " ] betű nincs benne.");
                                Console.WriteLine("MÉG [ " + HIBA_LEHET + " ] PRÓBÁLKOZÁSOD VAN");
                                BETU_NINCS.Add(BEMENETI_BETU.ToLower());

                            }

                        }
                    }
                  
                    if (OSSZES_BETU_SZAMA == 0)
                    {
                        Console.WriteLine("NYERTÉL");
                    }
                    else if (HIBA_LEHET == 0)
                    {
                        OSSZES_BETU_SZAMA = 0;
                        Console.WriteLine("VESZTETTÉL");
                    }
                }
            #endregion



        }
    }

}


