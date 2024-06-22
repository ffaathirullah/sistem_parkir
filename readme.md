Deskripsi:
Aplikasi Parkir adalah sebuah program sederhana yang memungkinkan pengguna untuk mengelola sistem parkir melalui konsol. Aplikasi ini dibangun menggunakan .NET 5 dan menyediakan berbagai fitur untuk check-in kendaraan, check-out kendaraan, dan melihat laporan statistik terkait parkir.

Fitur Utama:

Buat Tempat Parkir:

create_parking_lot <jumlah_slot>
Membuat tempat parkir dengan jumlah slot tertentu.
Check-In Kendaraan:

park <nomor_polisi> <warna> <jenis_kendaraan>
Memarkirkan kendaraan dengan nomor polisi, warna, dan jenis kendaraan tertentu.
Check-Out Kendaraan:

leave <nomor_slot>
Mengeluarkan kendaraan dari tempat parkir berdasarkan nomor slot.
Lihat Status Parkir:

status
Melihat status parkir saat ini, termasuk informasi nomor slot, nomor polisi, jenis kendaraan, dan warna.
Lihat Jumlah Kendaraan Berdasarkan Jenis:

type_of_vehicles <jenis_kendaraan>
Melihat jumlah kendaraan berdasarkan jenis kendaraan tertentu yang sedang diparkir.
Laporan Kendaraan dengan Plat Ganjil:

registration_numbers_for_vehicles_with_odd_plate
Melihat nomor registrasi kendaraan dengan nomor plat ganjil yang sedang diparkir.
Laporan Kendaraan dengan Plat Genap:

registration_numbers_for_vehicles_with_even_plate
Melihat nomor registrasi kendaraan dengan nomor plat genap yang sedang diparkir.
Laporan Kendaraan Berdasarkan Warna:

registration_numbers_for_vehicles_with_colour <warna_kendaraan>
Melihat nomor registrasi kendaraan dengan warna tertentu yang sedang diparkir.
Laporan Nomor Slot Berdasarkan Warna Kendaraan:

slot_numbers_for_vehicles_with_colour <warna_kendaraan>
Melihat nomor slot kendaraan dengan warna tertentu yang sedang diparkir.
Nomor Slot Berdasarkan Nomor Registrasi Kendaraan:

slot_number_for_registration_number <nomor_polisi>
Mencari nomor slot berdasarkan nomor registrasi kendaraan.