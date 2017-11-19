using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace OkeyDemo
{
    public partial class OkeyDemo : Form
    {    

        public OkeyDemo()
        {

            InitializeComponent();
           
            
        }
       
        //classların çağırılması
        Tiles tilesClass = new Tiles();
        GameMechanics game = new GameMechanics();
        Players players = new Players();

        
        private void OkeyDemo_Load(object sender, EventArgs e)
        {
            //player oluştur.
            Player[] playersArray = players.CreatePlayers();
           
            //taşları arraya at
            Tile[] allTiles = tilesClass.CreateTiles();
            //taşları karıştır.
            tilesClass.ShuffleArray(allTiles);
            //okeyi al
            Tile okey = game.GetOkeyTile(allTiles);
            //sahte okeyin değişkenlerini okeye göre ayarla(number ve color)
            game.FakeOkeyAdjustment(allTiles, okey);
            
            //ele eklenen taşlar stringi --- rastgele kullanıcı seçip taşları ellere dağıt 
           string[] handStringArray = players.AddTilesToHand( playersArray, allTiles);

            


            // Elleri labelda göster
            Player1.Text = handStringArray[0];
            Player2.Text = handStringArray[1];
            Player3.Text = handStringArray[2];
            Player4.Text = handStringArray[3];
            //okeyi labelda göster.
            OkeyLabel.Text = okey.Name;
            //kazananı belirler
            WinnerLabel.Text = game.HandStatus(playersArray,okey);
            
            
        }

        private void MixButton_Click(object sender, EventArgs e)
        {
            OkeyDemo NewForm = new OkeyDemo();
            NewForm.Show();
            this.Dispose(false);
        }
    }

    public class GameMechanics
    {

        public Tile GetOkeyTile(Tile[] _array, int set_count = 2)
        {//renk arrayini almak için tiles classı çağırıyoruz.
            Tiles tiles = new Tiles();
            Random rnd = new Random();
            //göstergeyi rasgele seçiyoruz
            int pointer =rnd.Next(_array.Length-1);
            int okey= 0;
            //eğer bulunan taş sahte okeyse sahte okey olmayana kadar dön
            if (pointer == _array.Length)
            {
                do
                {
                    pointer = rnd.Next(_array.Length-1);

                } while (pointer == _array.Length);


            }
           //göstergenin rengini ve numarasını buluyoruz.
            int pointerColor = pointer / 13;
            int pointerNumber = pointer % 13;

            if (pointerNumber == 12 )
            {// okey numarası 13 ise aynı rengin 1 numarasını al
                okey = (pointerColor * 13) + 1 ;
            }else if (pointerNumber < 12 && pointerNumber >= 0)
            {// okey numarası 13 değilse 1 arttır
                okey = pointer + 1;
            }
            else
            {// farklı bir değer çıkarsa hata ver.
                Console.WriteLine("Okey tasi numarasi bulunamadi!");
            }
            //okey numarası ve rengini bul
            int okeyColor = okey / 13 ;
            int okeyNumber = okey % 13;

             
            //taşı belirle
           
            if(okeyColor < 8 & okeyColor >= 4)
            {
                okeyColor -= 4;
            }
           
            Tile okeyTile = new Tile(tiles.colors[okeyColor], okeyNumber);
            
            //taşı döndür
            return okeyTile ;
        }

        //sahteOkey i numarası ve rengini gerçek okey gibi yapma
        public Tile[] FakeOkeyAdjustment(Tile[] _array ,Tile _okey )
        {
            Tile newFake = new Tile() ;
            
            for (int i = 0; i < _array.Length-1; i++)
            {
                if(_array[i].Color == "null" && _array[i].Number == 0)
                {
                    //adı aynı rengi ve numarası değişti
                    newFake = new Tile(_array[i].Name, _okey.Color, _okey.Number);
                    _array[i] = newFake;

                   
                }
            }

            return _array;

        }

         public string HandStatus(Player[] _players ,Tile _okey)
        {

            
            Tiles tiles = new Tiles();
            List<string> handColor = new List<string>();
            List<int> handNumber = new List<int>();
            //playerların puanlarını tutar
            int[] playerPoints = new int[_players.Length];

            for (int i = 0; i < _players.Length; i++)
            {//elin renkleri alındı string listesine atıldı.
               
                foreach (Tile tile in _players[i].Hand)
                {
                    handColor.Add(tile.Color);
                }
                //elin sayıları alındı intlistesine atıldı.
                foreach (Tile tile in _players[i].Hand)
                {
                    handNumber.Add(tile.Number);
                }
                
                //aynı renktedi sayıları ile set olmayan taşları alıp 
                //renklerine göre
                List<int> handNumberTemp = new List<int>();
                List<string> handColorTemp = new List<string>();

                //aynı renkteki taşları tutacak liste
                List<string> handColorTreshold = new List<string>();
                List<int> handNumberTreshold = new List<int>();
               
                //playerın puanı bunda tutuluyor.
                int finishHolder = 0;
                Console.WriteLine("5");
                //do başlangıç
                do
                {//alttaki fora her ilk girdiğinde ilk önce 0ıncı elemanı alması için bool ile bir koşul kondu.
                    
                    bool controlOfFirstEleman=true;
                    for (int j = 1; j < handColor.Count; j++)
                    {
                        if(controlOfFirstEleman == true)
                        {
                            handColorTreshold.Add(handColor[0]);
                            handNumberTreshold.Add(handNumber[0]);
                            
                            controlOfFirstEleman = false;
                        }
                        Console.WriteLine("6");
                        //aynı renkteyse handcolorTrshold listesine ekle handcolordan çıkar.
                        //aynısıını name ve numbera da yap
                        if (handColor[0] == handColor[j])
                            {
                                handNumberTreshold.Add(handNumber[j]);
                                handColorTreshold.Add(handColor[j]);
                               
                                handColor.RemoveAt(j);
                                handNumber.RemoveAt(j);
                                

                            j--;
                            }
                       
                        //eğer listenin sonuna vardıysak ilkini sil
                        if (j == (handColor.Count - 1))
                        {
                            handColor.RemoveAt(0);
                            handNumber.RemoveAt(0);
                            
                        }
                    }
                    //numaraları küçükten büyüğe sırala
                    handNumberTreshold.Sort();
                    Console.WriteLine("7");
                    int point = -2;
                   int counter = 0;
                    
                    for (int j = 0; j < handNumberTreshold.Count; j++)
                    {//counter set yapmak için gerekli taş sayısını tutar.
                     //3 ten sonra taş gerekmediği için hep 0 olacaktır.
                     //çift taş var ise 2.taşa geç
                       
                        if (j + 1 < handNumberTreshold.Count) {
                            if ( handNumberTreshold[j] == handNumberTreshold[j + 1])
                            {
                                Console.WriteLine("8");
                                //if (handNumberTreshold[j] != _okey.Number || handColorTreshold[j] != _okey.Color)
                                //{
                                //burada çift taş var ise çiftini silmemek için çift olan taşın
                                //bir tanesi ile ilk taşı yer değiştiriyoruz
                                //counter artmadığı için çift olan taş dışarıda kalıyor.
                                int holder = handNumberTreshold[j];
                                    handNumberTreshold[j] = handNumberTreshold[j - counter];
                                    handNumberTreshold[j - counter] = holder;
                                //}
                                if (handNumberTreshold[j] == _okey.Number && handColorTreshold[j] == _okey.Color)
                                {
                                  
                                    //okeyi sil okey jokerdir her yere uyar
                                    //handNumberTreshold.Remove(j);
                                    //okey silindiği için hepsi 1 azaldı.
                                    // j--;
                                    //okeyse taş 1 puan ekle
                                    point++;
                                }
                                Console.WriteLine("9");
                                continue;
                            }
                        }
                        //önceki taş sonraki taştan 1 fazla olduğu sürece countera ekle 0sa 0 bırak
                        if (j + 1 < handNumberTreshold.Count)
                        {
                            while (j + 1 < handNumberTreshold.Count && (handNumberTreshold[j] + 1) == handNumberTreshold[j + 1])
                            {
                                Console.WriteLine("10");

                                if (point < 0)
                                {
                                    point++;
                                }
                                //eğer değerimiz tutuyor ise bir sonraki taşa geçiyoruz
                                //bir sonraki değerin eşitliğini kontrol edip counterı arttırmaya devam ediyoruz.

                                j++;
                                //kaç taş ilerledik onun counterı
                                counter++;
                            }
                        }
                        //eğer eşit değil ise counterı alıp değerini finishHoldera atıyoruz bu sayı 
                        //ne kadar küçükse eli bitirmeye o kadar uzağız.
                        //değerler resetleniyor.
                        Console.WriteLine("11");
                        if (j + 1 < handNumberTreshold.Count) {
                            if (handNumberTreshold[j] + 1 != handNumberTreshold[j + 1])
                            {
                                
                               
                                if (counter >= 2)
                                {
                                    for (int k = 0; k < counter; k++)
                                    {
                                        handNumberTreshold.RemoveAt(j - counter + 1);
                                        handColorTreshold.RemoveAt(j - counter + 1);
                                    }

                                }

                                Console.WriteLine("12");
                                //FİX: argumentoutofrange  hatası veriyor.
                                //if (handNumberTreshold.Count != 0)
                                //{
                                //    if (handNumberTreshold[j] == _okey.Number && handColorTreshold[j] == _okey.Color)
                                //    {
                                //        // okey jokerdir her yere uyar



                                //        //okeyse taş 3 puan ekle 2 puan aşağıda çıkarılacak 1 puan değerinde okey
                                //        if (counter < 0)
                                //        {
                                //            finishHolder += 3;
                                //        }

                                //    }
                                //}
                                Console.WriteLine("13");
                                finishHolder += point;
                                point = -2;
                                counter = 0;

                            }
                        }

                    }
                    for (int k = 0; k < handNumberTreshold.Count; k++)
                    {
                        handNumberTemp.Add(handNumberTreshold[k]);
                        handColorTemp.Add(handColorTreshold[k]);
                        
                    }

                    if(handNumberTreshold.Count == 0)
                    {
                        break;
                    }

                    handNumberTreshold.Clear();
                    handColorTreshold.Clear();
                    Console.WriteLine("14");

                    

                } while (handColor.Count != 0);
                //renge göre puan sayacı
                int colorPoint = -2;
                Console.WriteLine("15");
                //handnumbertempe atılmış kalan taşları aynı numaralı farklı renkte olanlara bakıyoruz 
                for (int j = 1; j < handColorTemp.Count ; j++)
                {
                    if(handColorTemp[0] != handColorTemp[j] && handNumberTemp[0] == handNumberTemp[j] )
                    {
                        Console.WriteLine("16");
                        colorPoint++;
                        handNumberTemp.RemoveAt(j);
                        handColorTemp.RemoveAt(j);
                        j--;
                    }
                    if(j == (handColorTemp.Count - 1))
                    {
                        handNumberTemp.RemoveAt(0);
                        handColorTemp.RemoveAt(0);
                        finishHolder += colorPoint;
                        colorPoint = -2;

                    }

                }
                Console.WriteLine("17");
                playerPoints[i] = finishHolder;
                finishHolder = 0;
            }
            int winnerPoint= int.MinValue;
            int winnerIndex = 0;
            for (int i = 0; i < _players.Length; i++)
            {
                if(winnerPoint < playerPoints[i])
                {
                    winnerPoint = playerPoints[i];
                    winnerIndex = i;
                }
                Console.WriteLine("18");

            }

            return "Player" + winnerIndex + " kazandı.";

        } 



    }


    
    public class Tiles
    {
        public Tile[] tiles = new Tile[106];
        public string[] colors = { "sarı", "mavi", "siyah", "kırmızı" };
        public int tileCount  = 13;
        public int set_Count = 2;
        Tile tile;
        public Tile[] ShuffleArray(Tile[] _array)
        {
            Random r = new Random();
            for (int i = _array.Length; i > 0; i--)
            {
                int j = r.Next(i);
                Tile k = _array[j];
                _array[j] = _array[i - 1];
                _array[i - 1] = k;
            }
            return _array;
        }

        public Tile[] CreateTiles()
        {
            for (int k = 0; k < set_Count; k++)
            {
                for (int i = 0; i < colors.Length; i++)
                {
                    for (int j = 0; j < tileCount; j++)
                    {


                        tile = new Tile(colors[i], j + 1);

                        tiles[((i * tileCount)+(k*52)) + j] = tile;

                    }
                    
                }
   
                

            }
            Tile namedTile = new Tile("sahte_okey");
                tiles[tiles.Length-2] = namedTile;
               tiles[tiles.Length - 1] = namedTile;

            return tiles;
        }


    }


    public class Players
    {
        Player[] players = new Player[4];
        
        


        public Player[] CreatePlayers()
        {
            for (int i = 0; i < players.Length; i++)
            {
                //playerları oluşturduk
                Player player = new Player(i , "Player"+i);
                players[i] = player;

            }

            return players;
        }

        public int SelectRandomPlayer()
        {
            Random rnd = new Random();
            return rnd.Next(players.Length-1);
            
        }

        public string[] AddTilesToHand(Player[] _players , Tile[] _allTiles)
        {
            //rastgele player seç
            int randomPlayer = SelectRandomPlayer();
            //ele eklenen taşlar stringi
            string handString = "";
            //şu ana kadar eklenen taşların sayısı
            int addedTiles = 0;
            for (int i = 0; i < _players.Length; i++)
            {

                if (i == randomPlayer)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        _players[i].Hand.Add(_allTiles[i + addedTiles]);
                        handString = string.Concat(handString, " ", _allTiles[i + addedTiles].Name);
                        addedTiles++;

                    }
                    handString = string.Concat(handString, ",");
                }

                if (i != randomPlayer)
                {
                    for (int j = 0; j < 14; j++)
                    {
                        _players[i].Hand.Add(_allTiles[i + addedTiles]);
                        handString = string.Concat(handString, " ", _allTiles[i + addedTiles].Name);
                        addedTiles++;

                    }
                    handString = string.Concat(handString, ",");
                }

              

            }
            //bütün ',' ile ayrılıp string ile alınan elleri ayır. Arraya at.
            string[] handStringArray = new string[4];
            handStringArray = handString.Split(',');
            return handStringArray;
        }




    }

   /// <summary>
   /// Tile ve Player Classları
   /// </summary>


    //taşların özelliklerinin olduğu  class
    //şu anlık 2 overloadı vardır.
    public class Tile{

        private string name;
        private string color;
        private int number;
        
        public string Name { get => name; }
        public string Color { get => color;  }
        public int Number { get => number;  }

        public Tile(string _name ="Boş", string _color ="null" , int _number = 0)
        {
            name = _name;
            color = _color;
            number = _number;

        }

        public Tile(string _color, int _number)
        {
            color = _color;
            number = _number;
            name = (_color + _number).ToString();
        }

        
    }

    //kullanıcının özelliklerinin olduğu class
    public class Player
    {
        private int playerNumber;
        private string playerName;
        List<Tile> hand = new List<Tile>();
        
        public List<Tile> Hand { get => hand; set => hand = value; }
        public int PlayerNumber { get => playerNumber; set => playerNumber = value; }
        public string PlayerName { get => playerName; set => playerName = value; }

        public Player(int _playerNumber , string _playerName )
        {
            
            playerNumber = _playerNumber;
            playerName = _playerName;
        }

    }




}
