   M S B A M L   `   `   `  ����  pyrenaction!    pyrenaction.Views.ucTabBord   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5       �� 
TargetType   WrapText �� Property �� Value��%T   &	        �� 5	   
   " ��6   .�5
      ��  � ��$
 Wrap=�6-   5      5      .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ myDashboard��5         AutoGenerateColumns .     
IsReadOnly .    Columns 5   
   0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6!   	   Header$		 N°��6-   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 69   �� *id+  5      $	 	Création��6!   
 63   �� *date1+  5      $	 Délais��6!   
 61   �� *date2+  5      $	 Source��6!      ElementStyle# [  61      MaxWidth$	 300Q�6Z   
 6j   �� *source+  5      $	 Analyse��6!   # [  62   $	 300Q�6[   
 6k   �� *	analyse+  5      $	 Description��6!   # [  66   $	 300Q�6_   
 6n   �� *description+  5      $	 Statut��6!   
 61   �� *statut+  5      $	 
Importance��6!   
 65   �� *
importance+  5      $	 Famille��6!   
 62   �� *	famille+  5      $
	 Site��6!   
 6/   �� *site+  5      $	 Questionnaire��6!   
 68   �� *questionnaire+  5      $	 Liée��6!   # [  6/   $	 300Q�6X   
 6h   �� *	parente+4  .System.Windows.Controls.DataGridTemplateColumn  5      $	 Taches rattachées��6%      CellTemplate 5      �� 5      .R�5      �� ��6"   �� *taches+��6A   Z� ��5      �� 5    "   .R�5!   &   �� ��60   �� *nom+��6E   �� *color+6d   5"   #   5$      5%      5'        5(      $	 Liens rattachées��6%    5)      �� 5*      .R�5+      �� ��6"   �� *liens+��6A   Z� ��5,      �� 5-   "   .R�5.   &   �� �� 5/   (   -   5        ��5/   2   �� *url+.�6z   .�50   +   > �� ��65   �� *nom+51   )   52   '   53   #   55      56      58        59      $	 Responsable 1��6!   
 68   �� *utilisateur1+  5:      $	 Responsable 2��6!   
 68   �� *utilisateur2+  5;      $	 % Avancement��6!   
 67   �� *pourcentage+5=      5A      