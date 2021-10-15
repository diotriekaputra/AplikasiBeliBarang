using System;
using System.Collections.Generic;
using System.Text;

namespace AplikasiBarang
{
	public class SDA
	{

		public string namaBarang { get; set; }
		public int lamaPembelian { get; set; }
		public int banyakBarang { get; set; }
		public string jenis { get; set; }
		private int harga { get; set; }
		public int Harga
		{
			get { return harga; }
			set { harga = value; }
		}

		public static int hargaAwal = 100000;

		public static int HitungHarga(int lamaPembelian, int banyakBarang, int hargaAwal, string jenis)
		{
			int hargaPotong;
			int hargaBarang;

			if (jenis == "Premium")
			{
				hargaAwal = 2 * hargaAwal;
			}
			else
			{
				hargaAwal = hargaAwal;
			}
			if (lamaPembelian >= 1)
			{
				int potong = 2000;
				hargaPotong = hargaAwal - potong * (lamaPembelian / 1);
			}
			else
			{
				hargaPotong = hargaAwal;
			}
			if (banyakBarang >= 2)
			{
				int diskon = 1000;
				hargaBarang = hargaPotong - diskon * (banyakBarang / 1);
			}
			else
			{
				hargaBarang = hargaPotong;
			}
			return hargaBarang;
		}
	}
}
