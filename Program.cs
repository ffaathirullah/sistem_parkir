using System;
using System.Collections.Generic;
using System.Linq;

namespace parking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ParkingSystem parkingSystem = new ParkingSystem();

            while (true)
            {
                Console.WriteLine("Masukkan perintah:");
                string input = Console.ReadLine();
                string[] instruksi = input.Split(' ');

                switch (instruksi[0])
                {
                    case "create_parking_lot":
                        int kapasitas = int.Parse(instruksi[1]);
                        parkingSystem.BuatTempatParkir(kapasitas);
                        break;

                    case "park":
                        string nomorPolisi = instruksi[1];
                        string warna = instruksi[2];
                        string jenisKendaraan = instruksi[3];
                        parkingSystem.ParkirKendaraan(nomorPolisi, warna, jenisKendaraan);
                        break;

                    case "leave":
                        int nomorSlot = int.Parse(instruksi[1]);
                        parkingSystem.KeluarParkir(nomorSlot);
                        break;

                    case "status":
                        parkingSystem.StatusParkir();
                        break;

                    case "type_of_vehicles":
                        string jenis = instruksi[1];
                        parkingSystem.JumlahKendaraan(jenis);
                        break;

                    case "registration_numbers_for_vehicles_with_odd_plate":
                        parkingSystem.PlatGanjil();
                        break;

                    case "registration_numbers_for_vehicles_with_even_plate":
                        parkingSystem.PlatGenap();
                        break;

                    case "registration_numbers_for_vehicles_with_colour":
                        string warnaKendaraan = instruksi[1];
                        parkingSystem.PlatWarna(warnaKendaraan);
                        break;

                    case "slot_numbers_for_vehicles_with_colour":
                        string warnaSlot = instruksi[1];
                        parkingSystem.SlotWarna(warnaSlot);
                        break;

                    case "slot_number_for_registration_number":
                        string nomorPlat = instruksi[1];
                        parkingSystem.SlotBerdasarkanPlat(nomorPlat);
                        break;

                    case "exit":
                        return;

                    default:
                        Console.WriteLine("Perintah tidak ditemukan");
                        break;
                }
            }
        }
    }

    public class ParkingSystem
    {
        private List<Kendaraan> _slotParkir;
        private int _kapasitas;
        private bool _dibuat = false;

        public ParkingSystem()
        {
        
        }

        public void BuatTempatParkir(int count)
        {
            _kapasitas = count;
            _slotParkir = new List<Kendaraan>(_kapasitas);
            for (int i = 0; i < count; i++)
            {
                _slotParkir.Add(null);
            }

            _dibuat = true;
            Console.WriteLine($"Berhasil membuat tempat parkir dengan {count} slot");
        }

        public void ParkirKendaraan(string nomorPolisi, string warna, string jenis)
        {
            if (!_dibuat)
            {
                Console.WriteLine("Tempat parkir belum dibuat!!!");
                return;
            }
        
            for (int i = 0; i < _kapasitas; i++)
            {
                if (_slotParkir[i] == null)
                {
                    _slotParkir[i] = new Kendaraan
                    {
                        NomorSlot = i + 1,
                        NomorPolisi = nomorPolisi,
                        Warna = warna,
                        JenisKendaraan = jenis
                    };
                    Console.WriteLine($"Slot nomor: {i + 1} berhasil dialokasikan");
                    return;
                }
            }
            Console.WriteLine("Maaf, tempat parkir penuh");
        }

        public void KeluarParkir(int nomorSlot)
        {
            if (nomorSlot > _kapasitas || _slotParkir[nomorSlot - 1] == null)
            {
                Console.WriteLine($"Slot nomor {nomorSlot} sudah kosong");
            }
            else
            {
                _slotParkir[nomorSlot - 1] = null;
                Console.WriteLine($"Slot nomor {nomorSlot} sudah kosong");
            }
        }

        public void StatusParkir()
        {
            Console.WriteLine("Slot\tNomor\t\tJenis\tNomor Polisi\tWarna");
            for (int i = 0; i < _kapasitas; i++)
            {
                if (_slotParkir[i] != null)
                {
                    Console.WriteLine($"{i + 1}\t{_slotParkir[i].NomorPolisi}\t{_slotParkir[i].JenisKendaraan}\t{_slotParkir[i].Warna}");
                }
            }
        }

        public void JumlahKendaraan(string jenis)
        {
            int count = _slotParkir.Count(x => x != null && x.JenisKendaraan == jenis);
            Console.WriteLine(count);
        }

        public void PlatGanjil()
        {
            var kendaraan = _slotParkir.Where(x => x != null && int.Parse(x.NomorPolisi.Split('-')[1]) % 2 != 0).Select(x => x.NomorPolisi);
            Console.WriteLine(string.Join(", ", kendaraan));
        }

        public void PlatGenap()
        {
            var kendaraan = _slotParkir.Where(x => x != null && int.Parse(x.NomorPolisi.Split('-')[1]) % 2 == 0).Select(x => x.NomorPolisi);
            Console.WriteLine(string.Join(", ", kendaraan));
        }

        public void PlatWarna(string warna)
        {
            var kendaraan = _slotParkir.Where(x => x != null && x.Warna == warna).Select(x => x.NomorPolisi);
            Console.WriteLine(string.Join(", ", kendaraan));
        }

        public void SlotWarna(string warna)
        {
            var slot = _slotParkir.Where(x => x != null && x.Warna == warna).Select(x => x.NomorSlot);
            Console.WriteLine(string.Join(", ", slot));
        }

        public void SlotBerdasarkanPlat(string nomorPolisi)
        {
            var slot = _slotParkir.FirstOrDefault(x => x != null && x.NomorPolisi == nomorPolisi)?.NomorSlot;
            if (slot != null)
            {
                Console.WriteLine(slot);
            }
            else
            {
                Console.WriteLine("Tidak Ditemukan");
            }
        }
    }

    public class Kendaraan
    {
        public int NomorSlot { get; set; }
        public string NomorPolisi { get; set; }
        public string Warna { get; set; }
        public string JenisKendaraan { get; set; }
    }
}
