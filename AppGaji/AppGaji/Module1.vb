Imports System.Console
Imports System.IO

Module Module1

    Sub Main()
        Dim strNama As String
        Dim intGolongan As Integer
        Dim strJabatan As String
        Dim strPegawai As String
        Dim strJk As String
        Dim strKawin As String
        Dim intJmlAnak As Integer
        Dim intGajiPokok As Integer
        Dim intTunjIstri As Integer
        Dim intTunjAnak As Integer
        Dim intGajiBruto As Integer
        Dim intKoperasi As Integer
        Dim intBiayaJab As Integer
        Dim intDanaPensiun As Integer
        Dim intGajiNetto As Integer
        Dim ulang1 As Boolean
        Dim ulang2 As Boolean
        Dim ulang3 As Boolean
        Dim ulang4 As Boolean
        Dim ulang5 As Boolean

        ulang1 = True
        ulang2 = True
        ulang3 = True
        ulang4 = True
        ulang5 = True
        intJmlAnak = 0
        intKoperasi = 0

        WriteLine()
        WriteLine("    PROGRAM SLIP GAJI")
        WriteLine("-------------------------")
        Write("Nama : ")
        strNama = ReadLine()

        Do While ulang1 = True
            WriteLine()
            WriteLine("1. Apa golongan anda?")
            WriteLine("   1. Golongan 1")
            WriteLine("   2. Golongan 2")
            WriteLine("   3. Golongan 3")
            Write("   Golongan = ")
            intGolongan = ReadLine()
            If intGolongan <> 1 And intGolongan <> 2 And intGolongan <> 3 Then
                WriteLine("Golongan yang anda masukkan salah!")
            Else
                ulang1 = False
            End If
        Loop

        Do While ulang2 = True
            WriteLine()
            WriteLine("2. Apa jabatan anda?")
            WriteLine("   A. Kepala")
            WriteLine("   B. Manager")
            WriteLine("   C. Umum")
            Write("   Jabatan = ")
            strJabatan = UCase(ReadLine())
            If strJabatan <> "A" And strJabatan <> "B" And strJabatan <> "C" Then
                WriteLine("Jabatan yang anda masukkan salah!")
            Else
                ulang2 = False
            End If
        Loop

        Do While ulang3 = True
            WriteLine()
            WriteLine("3. Apa status pegawai anda?")
            WriteLine("   A. Tetap")
            WriteLine("   B. Honorer")
            Write("   Status pegawai = ")
            strPegawai = UCase(ReadLine())
            If strPegawai <> "A" And strPegawai <> "B" Then
                WriteLine("Status pegawai yang anda masukkan salah ")
            Else
                ulang3 = False
            End If
        Loop

        Do While ulang4 = True
            WriteLine()
            Write("4. Apa jenis kelamin anda? (P/L) = ")
            strJk = UCase(ReadLine())
            If strJk <> "P" And strJk <> "L" Then
                WriteLine("Jenis kelamin yang anda masukkan salah!")
            Else
                ulang4 = False
            End If
        Loop

        Do While ulang5 = True
            WriteLine()
            WriteLine("5. Status kawin anda? ")
            WriteLine("   A. Kawin")
            WriteLine("   B. Belum")
            Write("   Status kawin = ")
            strKawin = UCase(ReadLine())

            If strKawin = "A" Then
                WriteLine()
                Write("   Jumlah anak anda = ")
                intJmlAnak = intJmlAnak + ReadLine()
                ulang5 = False
            ElseIf strKawin = "B" Then
                ulang5 = False
            Else
                WriteLine("Status kawin yang anda masukkan salah!")
            End If

        Loop
        
        If intGolongan = 1 Then
            intGajiPokok = 1500000
        ElseIf intGolongan = 2 Then
            intGajiPokok = 2500000
        ElseIf intGolongan = 3 Then
            intGajiPokok = 3500000
        End If

        If strJk = "L" And strKawin = "A" Then
            If intGolongan = 1 Then
                intTunjIstri = 0.01 * intGajiPokok
            ElseIf intGolongan = 2 Then
                intTunjIstri = 0.03 * intGajiPokok
            ElseIf intGolongan = 3 Then
                intTunjIstri = 0.05 * intGajiPokok
            End If
        End If

        If strKawin = "A" And intJmlAnak > 0 Then
            If intJmlAnak <= 2 Then
                intTunjAnak = (0.01 * intGajiPokok) * intJmlAnak
            Else
                intTunjAnak = (0.01 * intGajiPokok) * 2
            End If
        End If

        intGajiBruto = intGajiPokok + intTunjAnak + intTunjIstri

        If strPegawai = "A" Then
            intKoperasi = 5000
        End If

        If strJabatan = "A" Then
            intBiayaJab = 0.005 * intGajiPokok
        ElseIf strJabatan = "B" Then
            intBiayaJab = 0.003 * intGajiPokok
        End If

        If strPegawai = "A" Then
            If strJabatan = "A" Then
                intDanaPensiun = 0.005 * intGajiPokok
            ElseIf strJabatan = "B" Then
                intDanaPensiun = 0.003 * intGajiPokok
            End If
        End If

        intGajiNetto = intGajiBruto - (intKoperasi + intBiayaJab + intDanaPensiun)

        WriteLine()
        WriteLine("-------------------------")
        WriteLine("SLIP GAJI : " & strNama)
        WriteLine("-------------------------")
        WriteLine("1. Golongan            : " & intGolongan)
        If strJabatan = "A" Then
            WriteLine("2. Jabatan             : Kepala")
        ElseIf strJabatan = "B" Then
            WriteLine("2. Jabatan     : Manager")
        ElseIf strJabatan = "B" Then
            WriteLine("2. Jabatan     : Umum")
        End If

        If strPegawai = "A" Then
            WriteLine("3. Status Pegawai      : Tetap")
        ElseIf strPegawai = "B" Then
            WriteLine("3. Status Pegawai      : Honorer")
        End If

        If strJk = "L" Then
            WriteLine("4. Jenis Kelamin       : Laki-laki")
        ElseIf strJk = "P" Then
            WriteLine("4. Jenis Kelamin       : Perempuan")
        End If

        If strKawin = "A" Then
            WriteLine("5. Status Kawin        : Kawin")
        ElseIf strKawin = "B" Then
            WriteLine("5. Status Kawin        : Belum")
        End If

        WriteLine("6. Jumlah anak         : " & intJmlAnak)
        WriteLine("7. Gaji Pokok          : Rp " & FormatNumber(Convert.ToInt32(intGajiPokok)), 0, TriState.True, 0)
        WriteLine("8. Tunjangan Istri     : Rp " & FormatNumber(Convert.ToInt32(intTunjIstri)), 0, TriState.True, 0)
        WriteLine("9. Tunjangan Anak      : Rp " & FormatNumber(Convert.ToInt32(intTunjAnak)), 0, TriState.True, 0)
        WriteLine("        Gaji Bruto     : Rp " & FormatNumber(Convert.ToInt32(intGajiBruto)), 0, TriState.True, 0)
        WriteLine("10. Potongan Koperasi  : Rp " & FormatNumber(Convert.ToInt32(intKoperasi)), 0, TriState.True, 0)
        WriteLine("11. Biaya Jabatan      : Rp " & FormatNumber(Convert.ToInt32(intBiayaJab)), 0, TriState.True, 0)
        WriteLine("12. Dana Pensiun       : Rp " & FormatNumber(Convert.ToInt32(intDanaPensiun)), 0, TriState.True, 0)
        WriteLine("        Gaji Netto     : Rp " & FormatNumber(Convert.ToInt32(intGajiNetto)), 0, TriState.True, 0)
        WriteLine("-------------------------")
        WriteLine()
        WriteLine("Slip gaji telah tersimpan pada computer anda")

        Dim mydate As String = DateTime.Now.ToString("dd'-'MM'-'yyyy-HH-mm-ss")
        Dim filename As String

        filename = "Gaji " & strNama & " " & mydate & ".txt"

        Dim myWriter As StreamWriter
        myWriter = My.Computer.FileSystem.OpenTextFileWriter("D:\" & filename, True)

        myWriter.WriteLine()
        myWriter.WriteLine("-------------------------")
        myWriter.WriteLine("SLIP GAJI : " & strNama)
        myWriter.WriteLine("-------------------------")
        myWriter.WriteLine("1. Golongan            : " & intGolongan)
        If strJabatan = "A" Then
            myWriter.WriteLine("2. Jabatan             : Kepala")
        ElseIf strJabatan = "B" Then
            myWriter.WriteLine("2. Jabatan     : Manager")
        ElseIf strJabatan = "B" Then
            myWriter.WriteLine("2. Jabatan     : Umum")
        End If

        If strPegawai = "A" Then
            myWriter.WriteLine("3. Status Pegawai      : Tetap")
        ElseIf strPegawai = "B" Then
            myWriter.WriteLine("3. Status Pegawai      : Honorer")
        End If

        If strJk = "L" Then
            myWriter.WriteLine("4. Jenis Kelamin       : Laki-laki")
        ElseIf strJk = "P" Then
            myWriter.WriteLine("4. Jenis Kelamin       : Perempuan")
        End If

        If strKawin = "A" Then
            myWriter.WriteLine("5. Status Kawin        : Kawin")
        ElseIf strKawin = "B" Then
            myWriter.WriteLine("5. Status Kawin        : Belum")
        End If

        myWriter.WriteLine("6. Jumlah anak         : " & intJmlAnak)
        myWriter.WriteLine("7. Gaji Pokok          : Rp " & FormatNumber(Convert.ToInt32(intGajiPokok)), 0, TriState.True, 0)
        myWriter.WriteLine("8. Tunjangan Istri     : Rp " & FormatNumber(Convert.ToInt32(intTunjIstri)), 0, TriState.True, 0)
        myWriter.WriteLine("9. Tunjangan Anak      : Rp " & FormatNumber(Convert.ToInt32(intTunjAnak)), 0, TriState.True, 0)
        myWriter.WriteLine("        Gaji Bruto     : Rp " & FormatNumber(Convert.ToInt32(intGajiBruto)), 0, TriState.True, 0)
        myWriter.WriteLine("10. Potongan Koperasi  : Rp " & FormatNumber(Convert.ToInt32(intKoperasi)), 0, TriState.True, 0)
        myWriter.WriteLine("11. Biaya Jabatan      : Rp " & FormatNumber(Convert.ToInt32(intBiayaJab)), 0, TriState.True, 0)
        myWriter.WriteLine("12. Dana Pensiun       : Rp " & FormatNumber(Convert.ToInt32(intDanaPensiun)), 0, TriState.True, 0)
        myWriter.WriteLine("        Gaji Netto     : Rp " & FormatNumber(Convert.ToInt32(intGajiNetto)), 0, TriState.True, 0)
        myWriter.WriteLine("-------------------------")
        myWriter.Close()
    End Sub


End Module
