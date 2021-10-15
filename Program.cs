using System;
using System.Collections.Generic;

namespace AplikasiBarang
{
	public class Program : SDA
	{
		public static void Main()
		{
			List<Barang> daftarBarang = new List<Barang>();

			daftarBarang.Add(new Barang("Meja Merk Cosmos", 2, 5, "Biasa"));
			daftarBarang.Add(new Barang("Meja Merk Wadesta", 1, 3, "Biasa"));
			daftarBarang.Add(new Barang("Meja Merk Hermes", 3, 3, "Premium"));
			daftarBarang.Add(new Barang("Meja Merk Douyin", 1, 1, "Biasa"));
			int Exit = 0;
			do
			{
				int ketikAngka;
				menu();
				ketikAngka = int.Parse(Console.ReadLine());
				switch (ketikAngka)
				{
					case 1:
						InputData(daftarBarang);
						break;
					case 2:
						EditData(daftarBarang);
						break;
					case 3:
						ShowData(daftarBarang);
						break;
					case 4:
						DeleteData(daftarBarang);
						break;
					case 5:
						Exit = 1;
						Console.Clear();
						break;
				}
			} while (Exit == 0);
		}

		public static void menu()
		{
			Console.Clear();
			Console.WriteLine("--- Apa yang ingin anda lakukan? ---");
			Console.WriteLine();
			Console.WriteLine("1. Input Data Barang: ");
			Console.WriteLine("2. Edit Data Barang: ");
			Console.WriteLine("3. Show Data Barang: ");
			Console.WriteLine("4. Delete Data Barang: ");
			Console.WriteLine("5. Exit Aplikasi : ");
			Console.WriteLine();
			Console.WriteLine("--- Masukkan angka ---");
		}

		public static void InputData(List<Barang> DaftarBarang)
		{
			Console.WriteLine("=== Masukkan Data Barang Terbaru ===");
			SDA brg = new SDA();
			Console.Write("Nama Barang: ");
			brg.namaBarang = Console.ReadLine();
			Console.Write("Lama Pembelian : ");
			brg.lamaPembelian = int.Parse(Console.ReadLine());
			Console.Write("Banyak barang : ");
			brg.banyakBarang = int.Parse(Console.ReadLine());
			Console.Write("Jenis(1 = Biasa, 2 = Premium) : ");
			int x = int.Parse(Console.ReadLine());
			try
			{
				if (x == 1)
				{
					brg.jenis = "Biasa";
				}
				else if (x == 2)
				{
					brg.jenis = "Premium";
				}
			}
			catch (Exception)
			{
				Console.WriteLine("Silahkan ketik angka 1 atau 2.");
				Console.ReadLine();
				Console.Clear();
			}

			DaftarBarang.Add(new Barang(brg.namaBarang, brg.lamaPembelian, brg.banyakBarang, brg.jenis));
			Console.ReadLine();
			Console.WriteLine("Data sudah diinput, tekan Enter Untuk Melanjutkan");
			Console.ReadLine();
		}

		public static void ShowData(List<Barang> DaftarBarang)
		{
			int i = 1;
			Console.WriteLine("=== Barang Perseroan Terbatas Karya ===");
			foreach (var barang in DaftarBarang)
			{
				Console.WriteLine($"Barang id {i} :");
				Console.WriteLine($"Nama Barang : {barang.namaBarang}");
				Console.WriteLine($"Lama Pembelian : {barang.lamaPembelian} Tahun ");
				Console.WriteLine($"Banyak Barang : {barang.banyakBarang} Buah ");
				Console.WriteLine($"Harga Per Barang : Rp {barang.Harga}");
				Console.WriteLine();
				i += 1;
			}
			Console.WriteLine("Tekan Enter Untuk Melanjutkan");
			Console.ReadLine();
		}

		public static void EditData(List<Barang> DaftarBarang)
		{
			Console.WriteLine("Nama-Nama Barang : ");
			int i = 1;
			foreach (var barang in DaftarBarang)
			{
				Console.WriteLine($"{i}.{barang.namaBarang}");
				i += 1;
			}
			int edit = 0;
			do
			{
				Console.WriteLine("Nama barang yang akan diedit : ");
				string namaEdit = Console.ReadLine();

				foreach (var barang in DaftarBarang)
				{
					if (namaEdit == barang.namaBarang)
					{
						Console.WriteLine("Data yang akan diubah : ");
						Console.WriteLine($"Nama Barang : {barang.namaBarang}");
						Console.WriteLine($"Lama Pembelian : {barang.lamaPembelian} Tahun ");
						Console.WriteLine($"Banyak Barang : {barang.banyakBarang} Buah ");
						Console.WriteLine();
						Console.WriteLine("Masukan data baru : ");
						Console.WriteLine("Nama Barang: ");
						barang.namaBarang = Console.ReadLine();
						Console.WriteLine("Lama Pembelian : ");
						barang.lamaPembelian = int.Parse(Console.ReadLine());
						Console.WriteLine("Banyak Barang : ");
						barang.banyakBarang = int.Parse(Console.ReadLine());
						Console.WriteLine("Jabatan (1 = Biasa, 2 = Premium): ");
						int x = int.Parse(Console.ReadLine());
						try
						{
							if (x == 1)
							{
								barang.jenis = "Biasa";
							}
							else if (x == 2)
							{
								barang.jenis = "Premium";
							}

							barang.Harga = HitungHarga(barang.lamaPembelian, barang.banyakBarang, hargaAwal, barang.jenis);
							edit = 1;
							break;
						}
						catch (Exception)
						{
							Console.WriteLine("Silahkan ketik angka 1 atau 2.");
							Console.ReadLine();
							Console.Clear();
						}
					}
					else
					{
						edit = 0;
					}
				}
				if (edit == 0)
				{
					Console.WriteLine("Data Tidak Ada");
				}
			} while (edit == 0);
			Console.WriteLine("Data sudah diubah, Tekan enter untuk melanjutkan ");
			Console.ReadLine();
		}

		public static void DeleteData(List<Barang> DaftarBarang)
		{
			Console.WriteLine("Nama Barang : ");
			int k = 1;
			foreach (var barang in DaftarBarang)
			{
				Console.WriteLine(k + ". " + barang.namaBarang);
				k += 1;
			}
			int hapus = 0;
			do
			{
				Console.WriteLine("ID barang yang akan dihapus : ");
				int nomor = int.Parse(Console.ReadLine());

				if (nomor > DaftarBarang.Count)
				{
					hapus = 0;
				}
				else if (nomor <= DaftarBarang.Count)
				{
					hapus = 1;
					DaftarBarang.RemoveAt(nomor - 1);
				}
				if (hapus == 0)
				{
					Console.WriteLine("Data Tidak Ada");
				}
			}
			while (hapus == 0);
		}


	}

}
