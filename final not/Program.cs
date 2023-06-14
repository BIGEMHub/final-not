using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_not
{
	internal class Program
	{
		static int max(int a, int b)
		{
			if (a > b)
			{
				return a;
			}
			else return b;
		}

		class btree
		{
			public int data;
			public int ch;
			public string huffman;
			public btree left;
			public btree right;

		}
		static void createtree(btree[] bt)

		{
			if (bt[1] == null) return;

			btree b = new btree();

			b.left = bt[0];
			b.right = bt[1];

			b.data = bt[0].data + bt[1].data;

			bt[0] = b;
			bt[1] = null;

			Array.Sort(bt, (object x, object y) =>
			{

				int a = 0;
				if (x == null && y == null) return 0;
				if (x == null) return 1;
				if (y == null) return -1;

				if (((btree)x).data < ((btree)y).data) a = -1;
				if (((btree)x).data > ((btree)y).data) a = 1;
				return a;
			});
			createtree(bt);
		}
		static void huffmanstryaz(btree bt, string yon)
		{

			if (bt == null) return;

			if (bt.left == null) bt.huffman = yon;
			huffmanstryaz(bt.left, yon + "0");
			if (bt.right == null) bt.huffman = yon;
			huffmanstryaz(bt.right, yon + "1");

		}
		static string huffmanfind(btree bt, int ch)
		{
			if (bt == null) return "";
			if (bt.ch == ch) return bt.huffman;
			return huffmanfind(bt.left, ch);
			return huffmanfind(bt.right, ch);
			
		}

		static void huffmanyazdir(btree bt)
		{
			if (bt == null) return;
			if (bt.left == null) Console.WriteLine("{9} {1}", (char)bt.ch, bt.huffman);
			huffmanyazdir(bt.left);
			huffmanyazdir(bt.right);
		}
		//-------------------------------------------------------------------------
		static bool PalindromMu(string kelime)
		{
			int sol = 0;
			int sag = kelime.Length - 1;

			while (sol < sag)
			{
				if (kelime[sol] != kelime[sag])
				{
					return false;
				}
				sol++;
				sag--;
			}

			return true;

		}

		static string EnUzunPalindrom(string metin)
		{
			string[] kelimeler = metin.Split(' ');
			string uzunPalindrom = "";

			foreach (string kelime in kelimeler)
			{
				if (PalindromMu(kelime) && kelime.Length > uzunPalindrom.Length)
				{ uzunPalindrom = kelime; }
			}
			return uzunPalindrom;
		}
		//--------------------------------------------------------------------------------------------
		static int[] DizileriBirlestir(params int[][] diziler)
		{
			int toplamBoyut = 0;
			foreach (int[] dizi in diziler)
			{
				toplamBoyut += dizi.Length;
			}

			int[] birlesikDizi = new int[toplamBoyut];
			int[] diziIndisleri = new int[diziler.Length];

			for (int i = 0; i < toplamBoyut; i++)
			{
				int minIndis = -1;
				int minDeger = int.MaxValue;


				for (int j = 0; j < diziler.Length; j++)
				{
					int mevcutIndis = diziIndisleri[j];
					if (mevcutIndis < diziler[j].Length && diziler[j][mevcutIndis] < minDeger)
					{
						minIndis = j;
						minDeger = diziler[j][mevcutIndis];

					}
				}

				birlesikDizi[i] = minDeger;
				diziIndisleri[minIndis]++;

			}

			return birlesikDizi;
		}
		static void Main(string[] args)
		{
			#region 
			//--------------------vize sonrası 1.ders-------------------
			//4(1-1)/3+1/5-1/7+1/9-1/11............)
			// 1 eksi 1/3 +1/5 şeklinde gidiyo
			//ilk 10 bin terimi toplayalım
			//

			double sayi = 0;
			int f = 1;
			for (int i = 1; i < 20000; i = i + 2)//tek sayıları gitmesi için
			{
				sayi = sayi + (double)1 / i * f;
				f = f * -1;//bir eksi bir artı mantığı
			}
			sayi = sayi * 4;//parantez dışındaki 4 ile çarptık




			string s1 = "abcdefgh";
			string s2 = "axjbdch";
			//iki string in sub problemi longest common sequence 
			//arada farlşo harf olabilir şekilde ortak kelime 
			int[,] subsequance = new int[s1.Length, s2.Length];
			int adet = 0;
			for (int i = 0; i < s1.Length; i++)
			{
				for (int j = 0; j < s2.Length; j++)
				{
					if (s1[i] == s2[j])//eşitliği kıyaslamak için 
					{
						if (i == 0 && j == 0)//ilk satır veya sütun ise direk 1 yapıyoruz
						{
							subsequance[i, j] = 1;
						}
						else//sol çaprazın bir fazlasını al
						{
							subsequance[i, j] = subsequance[i - 1, j - 1] + 1;
						}
						if (subsequance[i, j] > adet) adet = subsequance[i, j];


					}
					else //eşit değilse üst yeva sola bak büyük olanı yaz
					{
						if (i == 0 || j == 0)
						{
							if (i == 0 && j == 0) { subsequance[i, j] = 0; }
							else
							{
								if (i == 0) subsequance[i, j] = subsequance[i, j - 1];
								if (j == 0) subsequance[i, j] = subsequance[i - 1, j];
							}
						}
						else
						{
							subsequance[i, j] = max(subsequance[i - 1, j], subsequance[i, j - 1]);
							//üst ve solu kontrol ettik
						}
					}
				}
			}
			Console.WriteLine(adet);



			//state programlama 

			string s1 = "abcdefgh";  //  10 ile sınırlı
			string s2 = "de";    //  s2  s1 için bir substring mi
								 // O(s1.length*s2.length)

			//  veri bir bütün 
			//  q0    d   q1  e    q2
			//  qo  d hariç kendine gidecek
			//  q1  d gelirse kendime  e gelirse 2 ye gideceğim diğer durumlarda q0 gideceğim 
			//  q2  ne gelirse gelsin kendinde kalacak

			int[,] q = new int[3, 10];
			q[0, 3] = 1;

			//for (int i = 0; i < 10; i++)
			//{
			//    q[1, i] = 0;
			//}
			q[1, 4] = 2;
			q[1, 5] = 3;


			for (int i = 0; i < 10; i++)
			{
				q[2, i] = 2;
			}

			int state = 0;

			for (int i = 0; i < s1.Length; i++)
			{
				state = q[state, s1[i] - 'a'];
			}
			if (state == 2) Console.WriteLine("bulundu");
			else Console.WriteLine("bulunmadı");


			//ab den sonra zorunlu olarak c gelmeli sorusu
			string s1 = "aaadfabcabc";
			int[,] q = new int[3, 10];
			int state = 0;

			q[0, 0] = 1;
			q[1, 0] = 1;
			q[1, 1] = 2;


			for (int i = 0; i < 10; i++)
			{
				q[2, i] = 3;
			}
			q[2, 2] = 0;
			int flag = 0;
			for (int i = 0; i < s1.Length; i++)
			{
				state = q[state, s1[i] - 'a'];
				if (state == 2) flag = 1;
				if (state == 3) { flag = 0; Console.WriteLine("kabul edilmedi"); break; }
			}

			//10010000    4 sıfır yan yana olmasını istiyor
			int[,] q = new int[4, 2];
			int state = 0;

			q[0, 1] = 0;
			q[0, 0] = 1;

			q[1, 0] = 2;
			q[1, 1] = 0;

			q[2, 0] = 3;
			q[2, 1] = 0;


			q[3, 0] = 3;
			q[3, 1] = 3;

			string s1 = "1110101000";
			for (int i = 0; i < s1.Length; i++)
			{
				state = q[state, s1[i] - '0'];
			}

			if (state == 3) Console.WriteLine("kabul edilmedi");
			else Console.WriteLine("kabul");







			//    abc def ghi    9 harf var
			//  abc  den 1 tanesi
			//  def den bir tane
			//  ghi  1 tane gelicek


			//  aeh
			//  a
			//  bf; bfh;     bfb red edilecek
			//  adgadgadgadgadgadg
			//  nasıl çözeriz

			//   a,b,c den biri gelecek   DEAD state   6 tane gelirse dead state
			//   q1  deyiz def bekliyoruz dead state
			//   q2 ghi den biri gelecek  dead state q0
			//  q0,  abc Q1,   def  Q2,  GHİ gelirse bizi q0 götürecek
			//  q3  dead state

			string s1 = "aadh";
			int[,] q = new int[4, 9];
			int state = 0;

			for (int i = 3; i < 9; i++)
			{
				q[0, i] = 3;
			}
			q[0, 0] = 1;
			q[0, 1] = 1;
			q[0, 2] = 1;


			for (int i = 0; i < 9; i++)
			{
				q[1, i] = 3;
			}
			q[1, 3] = 2;
			q[1, 4] = 2;
			q[1, 5] = 2;


			for (int i = 0; i < 9; i++)
			{
				q[2, i] = 3;
			}
			q[2, 6] = 0;
			q[2, 7] = 0;
			q[2, 8] = 0;


			for (int i = 0; i < 6; i++)
			{
				q[3, i] = 3;
			}

			for (int i = 0; i < s1.Length; i++)
			{
				state = q[state, s1[i] - 'a'];
			}
			if (state == 3) Console.WriteLine("kabul değil");
			else Console.WriteLine("kabul");





			//mod5=2 olan state sorusu
			string s1 = "1111110";
			//   (5*n*2*2 +1 )2= +1*2*2+1 =  1*5 2
			int[,] q = new int[5, 2];
			int state = 0;


			q[0, 0] = 0;
			q[0, 1] = 1;


			q[1, 0] = 2;
			q[1, 1] = 3;


			q[2, 0] = 4;
			q[2, 1] = 0;

			q[3, 0] = 1;
			q[3, 1] = 2;

			q[4, 0] = 3;
			q[4, 1] = 4;


			for (int i = 0; i < s1.Length; i++)
			{
				state = q[state, s1[i] - '0'];
			}
			if (state != 2) Console.WriteLine("kabul edilmiyor");
			else Console.WriteLine("Kabul ediyoruz");

			#endregion



			//huffman algoritmaları

			string s = "abcabbbbbbbbbcdbd";
			int[] f2 = new int[6];


			btree[] bt = new btree[4];


			for (int i = 0; i < s.Length; i++)
			{
				f2[s[i] - 'a']++;
			}


			for (int i = @; i < 4; i++)
			{
				bt[i] = new btree();
				bt[i].data = f2[i];
				bt[i].ch = 'a' + i;
			}

			Array.Sort(bt, (object x, object y) =>
					{

						int a = 0;
						if (x == null && y == null) return 0;
						if (x == null) return 1;
						if (y == null) return -1;

						if (((btree)x).data < ((btree)y).data) a = -1;
						if (((btree)x).data > ((btree)y).data) a = 1;
						return a;
					});


			createtree(bt);
			

			huffmanstryaz(bt[0], "");
			huffmanyazdir(bt[0]);
			huffmanfind(bt[0],1);
		}
	}
}
