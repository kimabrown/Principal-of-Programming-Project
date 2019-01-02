Module Module1

    Public Const NUMOFELE As Integer = 10

    Sub Main()
        Dim toSort(NUMOFELE) As Integer
        Dim Generator As System.Random = New System.Random()

        'Bubble Sort
        toSort = RandomizeArray(Generator)
        BubbleSort(toSort)
        Print("Bubble Sort: ", toSort)
        Console.WriteLine(" ")

        'Quick Sort
        toSort = RandomizeArray(Generator)
        QuickSort(toSort, 0, 9)
        Print("Quick Sort: ", toSort)
        Console.WriteLine(" ")

        'Merge Sort
        toSort = RandomizeArray(Generator)
        MergeSort(toSort, 0, 9)
        Print("Merge Sort: ", toSort)
        Console.WriteLine(" ")

        'Radix Sort
        toSort = RandomizeArray(Generator)
        RadixSort(toSort)
        Print("Radix Sort: ", toSort)
        Console.WriteLine(" ")


        Console.WriteLine(" ")
    End Sub

    Function BubbleSort(ByVal ParamArray toSort() As Integer)
        Dim a As Integer = -1
        Dim b As Integer = -1
        Dim changes As Integer = 1

        Do While changes > 0
            changes = 0
            For i = 0 To toSort.Length - 2
                If toSort(i + 1) < toSort(i) Then
                    changes = changes + 1
                    a = toSort(i + 1)
                    b = toSort(i)
                    toSort.SetValue(b, i + 1)
                    toSort.SetValue(a, i)
                End If
            Next i
        Loop

    End Function

    Function QuickSort(ByVal toSort() As Integer, ByVal low As Integer, ByVal high As Integer)
        Dim pivot As Integer
        Dim l As Integer
        Dim h As Integer
        Dim index As Integer
        Dim random As New Random

        If low >= high Then Exit Function

        index = random.Next(low, high + 1)
        pivot = toSort(index)

        toSort(index) = toSort(low)

        l = low
        h = high
        Do
            Do While toSort(h) >= pivot
                h = h - 1
                If h <= l Then Exit Do
            Loop
            If h <= l Then
                toSort(l) = pivot
                Exit Do
            End If

            toSort(l) = toSort(h)

            l = l + 1
            Do While toSort(l) < pivot
                l = l + 1
                If l >= h Then Exit Do
            Loop
            If l >= h Then
                l = h
                toSort(h) = pivot
                Exit Do
            End If

            toSort(h) = toSort(l)
        Loop

        QuickSort(toSort, low, l - 1)
        QuickSort(toSort, l + 1, high)
    End Function

    Function MergeSort(ByVal toSort() As Integer, ByVal low As Integer, ByVal high As Integer)
        If low >= high Then Return 0
        Dim length As Integer = high - low + 1
        Dim pivot As Integer = Math.Floor((low + high) / 2)
        MergeSort(toSort, low, pivot)
        MergeSort(toSort, pivot + 1, high)
        Dim temp(toSort.Length - 1) As Integer
        For i As Integer = 0 To length - 1
            temp(i) = toSort(low + i)
        Next
        Dim m1 As Integer = 0
        Dim m2 As Integer = pivot - low + 1
        For i As Integer = 0 To length - 1
            If m2 <= high - low Then
                If m1 <= pivot - low Then
                    If temp(m1) > temp(m2) Then
                        toSort(i + low) = temp(m2)
                        m2 += 1
                    Else
                        toSort(i + low) = temp(m1)
                        m1 += 1
                    End If
                Else
                    toSort(i + low) = temp(m2)
                    m2 += 1
                End If
            Else
                toSort(i + low) = temp(m1)
                m1 += 1
            End If
        Next
    End Function

    Function RadixSort(ByVal ParamArray toSort() As Integer)
        Dim radix = New Integer() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim k = 0

        'loop through 'toSort' and increment 'radix' for every occurence of a value
        For i = 0 To toSort.Length - 1
            radix(toSort(i)) += 1
        Next i

        'loop through 'radix' and set each value of 'toSort' incrementally
        For i = 0 To radix.Length - 1
            For j = 0 To radix(i) - 1
                toSort(k) = i
                k += 1
            Next j
        Next i

    End Function

    '            vvvv Tools vvvv
    Function RandomizeArray(Generator As System.Random) As Integer()

        Dim toRand(9) As Integer

        For i = 0 To toRand.Length - 1
            toRand.SetValue(Generator.Next(0, 9 + 1), i)
        Next i

        Print("Array to be Sorted: ", toRand)

        Return toRand
    End Function

    Function Print(heading As String, ByVal ParamArray toPrint() As Integer)

        Console.WriteLine(" ")
        Console.WriteLine(heading)

        For i = 0 To toPrint.Length - 1
            Console.Write(toPrint(i) & ", ")
        Next i
    End Function

End Module
