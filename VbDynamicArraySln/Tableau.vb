Public Class Tableau

#Region "Champs"
    ' Création tableau dynamique à taille vide.
    Private tab() As Integer
    Private trie = -1

#End Region

#Region "Méthodes"

    ' Méthode perméttant de redimensionné le tableau en lui indiquant une taille en paramètre.
    Public Sub New(ByVal n As Integer)
        ReDim tab(n)
    End Sub

    ' Méthode perméttant de redimensionné le tableau sans éffacées les données contenus.
    Public Sub SetNbElt(ByVal n As Integer)
        ReDim tab(n)
    End Sub

    ' Méthode/Fonction retournant la dimension du tableau.
    Public Function GetNbElt() As Integer
        Return UBound(tab)
    End Function

    ' Méthode perméttant de remplir le tableau de n ce qui permet de l'initialiser.
    Public Sub InitTab(ByVal n As Integer)
        Dim i As Integer
        For i = 0 To GetNbElt()
            tab(i) = n
        Next
        trie = 0
    End Sub

    ' Méthode perméttant de remplir le tableau de nombre aléatoire et ainsi l'initialiser.
    Public Sub InitAleatoire()
        For i = 0 To GetNbElt()
            Dim MyValue As Integer = Int((255.0F * Rnd()) + 1)
            tab(i) = MyValue
        Next
        trie = -1
    End Sub

    ' Méthode perméttant de remplir le tableau en fonction des indices 0 à n.
    Public Sub InitSequentiel()
        For i = 0 To GetNbElt()
            tab(i) = i
        Next
        trie = 1
    End Sub

    ' Méthode/Fonction retournant la valeur à un indice du tableau.
    Public Function GetValeur(ByVal indice As Integer) As Integer
        Return tab(indice)
    End Function

    ' Méthode/Fonction retournant la plus petite valeur du tableau.
    Public Function PlusPetitDeTab()
        Dim MyValue As Integer = tab(0)
        For i = 0 To GetNbElt()
            If tab(i) < MyValue Then
                MyValue = tab(i)
            End If
        Next
        Return MyValue
    End Function

    ' Méthode/Fonction retournant la plus grande valeur du tableau.
    Public Function PlusGrandDeTab()
        Dim MyValue As Integer = tab(0)
        For i = 0 To GetNbElt()
            If tab(i) > MyValue Then
                MyValue = tab(i)
            End If
        Next
        Return MyValue
    End Function

    ' Méthode/Fonction retournant l'indice de la plus petite valeur du tableau.
    Public Function PlusPetitIndiceDeTab()
        For i = 0 To GetNbElt()
            If tab(i) = PlusPetitDeTab() Then
                Return i
            End If
        Next
    End Function

    ' Méthode/Fonction retournant l'indice de la plus grande valeur du tableau.
    Public Function PlusGrandIndiceDeTab()
        For i = 0 To GetNbElt()
            If tab(i) = PlusGrandDeTab() Then
                Return i
            End If
        Next
    End Function

    ' Méthode permettant de permuté dans le tableau les valeurs situés en indice ind1 et ind2.
    Public Sub PermuterDansTab(ByVal ind1 As Integer, ByVal ind2 As Integer)
        Dim indice As Integer = tab(ind1)
        tab(ind1) = tab(ind2)
        tab(ind2) = indice
    End Sub

    ' Méthode permettant de trier le tableau par ordre croissant.
    Public Sub TriABullesCroissant()
        For i = 0 To GetNbElt() - 1
            For j = 0 To GetNbElt() - 1 ' Pour chaque élément regarde avec les autres valeurs ex: compare avec la premiere deuxieme troisieme etc
                If tab(j) > tab(j + 1) Then
                    PermuterDansTab(j, j + 1)
                End If
            Next
        Next
        trie = 1
    End Sub

    ' Méthode permettant de trier le tableau par ordre croissant.
    Public Sub TriABullesDecroissant()
        For i = 0 To GetNbElt() - 1
            For j = 0 To GetNbElt() - 1 ' Pour chaque élément regarde avec les autres valeurs ex: compare avec la premiere deuxieme troisieme etc
                If tab(j) < tab(j + 1) Then
                    PermuterDansTab(j, j + 1)
                End If
            Next
        Next
        trie = 2
    End Sub

    ' Méthode permettant de trier le tableau par selection croissante.
    Public Sub TriParSelectionCroissant()
        For i = 0 To GetNbElt()
            PermuterDansTab(i, PlusPetitIndiceDeTabDepuisPos(i))
        Next
        trie = -1
    End Sub

    ' Méthode permettant de trier le tableau par selection croissante.
    Public Sub TriParSelectionDecroissant()
        For i = 0 To GetNbElt()
            PermuterDansTab(i, PlusGrandIndiceDeTabDepuisPos(i))
        Next
        trie = -1
    End Sub

    ' Méthode/Fonction retournant la variable "trie" pour savoir comment le tableau est trié.
    Public Function estTrie()
        Return trie
    End Function
    ' Méthode permettant d'insérer une valeur supplémentaire dans le tableau.
    Public Sub InsererValeur(ByVal n As Integer)
        ReDim Preserve tab(GetNbElt() + 1)
        tab(GetNbElt()) = n
        Select Case trie
            Case 1
                TriABullesCroissant()
                MessageBox.Show("Le tableau actuel vient d'être re-trié par odre croissant.")
            Case 2
                TriABullesCroissant()
                MessageBox.Show("Le tableau actuel vien d'être re-trié par odre décroissant.")
            Case Else
                MessageBox.Show("La valeur " + Convert.ToString(n) + " à bien été insérer dans le tableau.")
        End Select
    End Sub

    ' Méthode permettant d'inverser les valeurs du tableau (premiere = derniere ...).
    Public Sub InverserTab()
        For i = 0 To GetNbElt() \ 2
            PermuterDansTab(i, GetNbElt() - i)
        Next
    End Sub

    ' Méthode/Fonction retournant l'indice de la plus petite valeur du tableau depuis la position choisi.
    Public Function PlusPetitIndiceDeTabDepuisPos(ByVal pos As Integer)
        Dim MyValue As Integer = tab(pos)
        Dim indicePetit = pos
        For i = pos To GetNbElt()
            If tab(i) < MyValue Then
                MyValue = tab(i)
                indicePetit = i
            End If
        Next
        Return indicePetit
    End Function

    ' Méthode/Fonction retournant l'indice de la plus grande valeur du tableau depuis la position choisi.
    Public Function PlusGrandIndiceDeTabDepuisPos(ByVal pos As Integer)
        Dim MyValue As Integer = tab(pos)
        Dim indiceGrand = pos
        For i = pos To GetNbElt()
            If tab(i) > MyValue Then
                MyValue = tab(i)
                indiceGrand = i
            End If
        Next
        Return indiceGrand
    End Function

    ' Méhode perméttant de supprimer une case à un indice donné.
    Public Sub SupprimerDansTab(ByVal ind As Integer)
        PermuterDansTab(ind, GetNbElt())
        ReDim Preserve tab(GetNbElt() - 1)
    End Sub

#End Region

End Class
