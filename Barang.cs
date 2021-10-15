using System;
using System.Collections.Generic;
using System.Text;

namespace AplikasiBarang
{
	public class Barang : SDA
	{
		public Barang(string namaBarang, int lamaPembelian, int banyakBarang, string jenis)
		{
			this.jenis = jenis;
			this.namaBarang = namaBarang;
			this.lamaPembelian = lamaPembelian;
			this.banyakBarang = banyakBarang;
			this.Harga = HitungHarga(lamaPembelian, banyakBarang, hargaAwal, jenis);
		}
	}
}
