   M S B A M L   `   `   `  ����N  JLibraryAssigmentWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:LibraryAssigmentWPF.UserControls LibraryAssigmentWPF.UserControls  5      1    +LibraryAssigmentWPF.UserControls.AddJournal   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:LibraryAssigmentWPF.UserControls     5        � 	Resources  5	         WhiteComboBoxStyle �� 
TargetType �� Property �� Value��%T   &	        �� 5
   
   " ��6+   .�5      ��  � ��
 �����6+   5      5      .��5      � 
���OO/� � RowDefinitions 5   
   �� 5      $	��.2* �6   �� 5      .+�5   
   (� .��5      �� $P��JПожалуйста, введите данные журнала ниже:��6   $��0��6H   $��Center=�6U   $��Center=�5      $
��Bold"�61   
�������$��David)�6V   5      � 5   
   $��1��6    5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5!      �� 5"      �� 5#      �� 5$      .+�5&      (� $��0��6   $��1��6#   $��Center=�63   $��Center=�6P   $��0,5,0,5q�6k   .��5'      7   1LibraryAssigmentWPF.UserControls.ClearableTextBox  -   5          Name$ isbnx��5'   )   $	��250��68   $��45��6D      	BoundText$
 ISBN��6P   5(      (� 5*      $��1��6   $��1��6#   $��Center=�63   $��Center=�6P   $��0,5,0,5q�6k   .��5+        -   5        $ namex��5+   )   $	��250��68   $��45��6D   $
 Name��6P   5,      (� 5.      $��2��6   $��1��6#   $��Center=�63   $��Center=�6P   $��0,5,0,5q�6k   .��5/        -   5        $ editionx��5/   )   $	��250��6;   $��45��6G   $ Edition��6S   50      (� 52      $��3��6   $��1��6#   $��Center=�63   $��Center=�6P   $��0,5,0,5q�6k   .��53        -   5        $ 	quantityx��53   )   $	��250��6<   $��45��6H   $ Quantity��6T   54      (� 56      $��4��6   $��1��6#   $��Center=�63   $��Center=�6P   $��0,5,0,5q�6k   .��57        -   5        $ pricex��57   )   $	��250��69   $��45��6E   $ Price��6Q   58      (� 5:      $��5��6   $��1��6#   $��0,5,0,5q�63   .��5;      �� -   5         ��Name$ btnEnter��5;      $��Добавить��6+   $��25(�6>   
�������
�����p�$��
UltraBlack"�5<   D   
�������$��3q�6w   $	��250��5=      $��45��6&   62   5>      (� 5@      $��6��6   $��1��6#   $��0,5,0,5q�63   .��5A      �� -   5        $ 	btnReturn��5A      $��
Назад��6,   $��25(�6<   
�������
�����p�$��
UltraBlack"�5B   C   
�������$��3q�6v   $	��250��5C      $��45��6&   62   5D      5E      5F      5G      