   M S B A M L   `   `   `  ����   pyrenaction!    pyrenaction.Views.ucTabBord   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � 	Resources   �� 
TargetType   WrapText �� Property �� Value��%/   &	        �� " ��.���  � ��$
 Wrap=�.+�&   System.Windows.Controls.DataGrid  -     Name$ myDashboard��   AutoGenerateColumns .     
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 	   Header$		 N°��1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *id+  $	 	Création��
 �� *date1+  $	 Délais��
 �� *date2+  $	 Source��   ElementStyle# [     MaxWidth$	 300Q�
 �� *source+  $	 Analyse��# [  $	 300Q�
 �� *	analyse+  $	 Description��# [  $	 300Q�
 �� *description+  $	 Statut��
 �� *statut+  $	 
Importance��
 �� *
importance+  $	 Famille��
 �� *	famille+  $
	 Site��
 �� *site+  $	 Questionnaire��
 �� *questionnaire+  $	 Liée��# [  $	 300Q�
 �� *	parente+4  .System.Windows.Controls.DataGridTemplateColumn  $	 Taches rattachées��   CellTemplate �� .R��� ���� *taches+��Z� ���� .R��� ���� *nom+���� *color+  $	 Liens rattachées�� �� .R��� ���� *liens+��Z� ���� .R��� �� -   ���� *url+.�.�> �� ���� *nom+  $	 Responsable 1��
 �� *utilisateur1+  $	 Responsable 2��
 �� *utilisateur2+  $	 % Avancement��
 �� *pourcentage+