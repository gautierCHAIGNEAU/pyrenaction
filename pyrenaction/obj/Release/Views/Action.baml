   M S B A M L   `   `   `  ���� F  Bpyrenaction, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:pyrenaction.Viewspyrenaction.Views      pyrenaction.Views.Action   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:pyrenaction.Views     $��554.328��.+��   J� RenderTransformOrigin$  0.501,0.501&�$
��Left=�$	��554��$��0,0,0,-0.14q� � RowDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* � � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� -    ��Name$ labelAction��$��Action liée��$��2��$��0��$��Right=��� -   $ 	labelDate��$
��Date��$��3��$��0��$��Right=��� -   $ labelDelais��$��Délais��$��4��$��0��$��Right=��� -   $ labelImportance��$��
Importance��$��5��$��0��$��Right=��� -   $ labelFamille��$��Famille��$��6��$��0��$��Right=��� -   $ 	labelSite��$
��Site��$��7��$��0��$��Right=��� -   $ labelResponsable1��$��Responsable 1��$��8��$��0��$��Right=��� -   $ labelResponsable1_Copy��$��Responsable 2��$��9��$��0��$��Right=��� -	   $ labelQuestionnaire��$��Questionnaire��$��10��$��0��$��Right=��� -
   $ labelSource��$��Source��$��12��$��0��$��Right=��� -   $ labelAnalyse��$��Analyse��$��13��$��0��$��Right=��� -   $ labelDescription��$��Description��$��14��$��0��$��Right=��� -   $ labelTaches��$��Tâches��$��15��$��0��$��Right=��� -   $ 
labelLiens��$��Liens��$��11��$��0��$��Right=�(  "System.Windows.Controls.DatePicker  -     Name$ 	inputDate��$��3��$��1��   SelectedDate �� *Date_a+ �� Mode$ TwoWay=��� -    ��Name$ inputAction��$ �� IsSynchronizedWithCurrentItem$
 TrueY�$��2��$��1������ *	Actions+�� -   $ inputImportance��$
 TrueY�$��5��$��1������ *Importances+�� -   $ inputFamille��$
 TrueY�$��6��$��1������ *
Familles+�� -   $ 	inputSite��$
 TrueY�$��7��$��1������ *Sites+�� -   $ inputResponsable1��$
 TrueY�$��8��$��1������ *Resp1+�� -   $ inputResponsable2��$
 TrueY�$��9��$��1������ *Resp2+�� -   $ inputQuestionnaire��$
 TrueY�$��10��$��1������ *Questionnaires+  -   $ inputDelais��$��4��$��1�� �� *Delais+$ TwoWay=��� -   $ 
inputLiens��$
 TrueY�$��11��$��1������ *Liens+�� -   	 ��Name$	 ajouterLien��$��Ajouter��$��11��$��2��$��5,0,5,0q��� -   $	 modifierLien��$��Modifier��$��11��$��3��$��5,0,5,0q��� -   $	 supprimerLien��$��	Supprimer��$��11��$��4��$��5,0,5,0q��� -   
 ��Name$
 inputSource��$��12��$��1��$��4������ *Source+�� -   $
 inputAnalyse��$��13��$��1��$��4������ *	Analyse+�� -   $
 inputDescription��$��14��$��1��$��4������ *Description+�� -   $ inputTaches��$
 TrueY�$��15��$��1������ *Taches+���� .R��� ���� *nom+���� *color+�� -    $	 ajouterTache��$��Ajouter��$��15��$��2��$��5,0,5,0q��� -!   $	 modifierTache��$��Modifier��$��15��$��3��$��5,0,5,0q��� -"   $	 supprimerTache��$��	Supprimer��$��15��$��4��$��5,0,5,0q��� -#   $	 buttonValider��$��Valider��$��17��$��1�� $   MaterialDesignRaisedAccentButton#���   �� -$   $ 
labelTitre��$��Gestion de l'action��$��0��$��2��$��center=��� -%    ��Name$ tacheControl��$��2��$��2��$��5��$��3��