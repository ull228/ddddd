   M S B A M L   `   `   `  ����N  JLibraryAssigmentWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:LibraryAssigmentWPF.UserControls LibraryAssigmentWPF.UserControls  5      3    -LibraryAssigmentWPF.UserControls.EditJournal2   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:LibraryAssigmentWPF.UserControls     5      .��5	   
   � 
���OO/�  � RowDefinitions  5
      �� 5      $��2* �6    �� 5      .+�5      (� $��	15,0,15,0q�6   .��5      �� -   5         ��Name$ title��5      $6��0Please choose the option you would like to edit:��6+   $��0��6c   $��Center=�6p   $��Center=�5      $
��Bold"�62   
�������$��David)�6W   5      � 5      $��1��6     5      �� 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      �� 5      �� 5      .+�5      (� -   5         (�Name$ viewBoxCombo��5      $��0��6,   $��1��69   $��Center=�6I   $��Center=�6d   $��5,50,5,6q�6�   .��5       �� -   5         ��Name$ comboBox��5       $	��250��6-   $��50��69   $��Center=�6E   $��20(�6`   $��Light"�6n   
�������
�������$��Center=�5!   >   $
��Left=�6`    �� Text$ Option��5"       �� 
IsEditable$
 True��6#    �� 
IsReadOnly$
 True��65   $|�False��6u   5#   ?   5$      1   +LibraryAssigmentWPF.UserControls.MenuButton  5%      -   5          Name$ btnEnter��5%      $��1��61   $��1��6>   $��5,5,5,0q�6N     5&      -   5        $ 	btnReturn��5&      $��2��62   $��1��6?   $	��Top=�6O   $��
5, 5, 5, 0q�6g   (� 5(      -   5        $ viewBoxTextBox��5(      $��0��62   $��1��6?   $��Center=�6O   $��Center=�6l   $��5, 50, 5, 0q�6�   $y�	Collapsed=�6�   .��5)      7   1LibraryAssigmentWPF.UserControls.ClearableTextBox  -   5        	  Name$	 editTextBox��5)   -   $	��250��6B   $��50��6N   5*      (� 5,      -   5        $ viewBoxEnter2��5,      $��1��61   $��1��6>   $��
5, 5, 5, 0q�6N   $y�	Collapsed=�6b   .��5-      �� -	   5        
 ��Name$
 	btnEnter2��5-      $
��Edit��60   $��18(�6?   
�������
�����p�$��
UltraBlack"�6w   
�������$��3q�5.   4   $��
0, 5, 6, 5q�6H   $	��255��6\   $��50��6k   $	��400��6z   $	��130��6�   6�   5/      (� 51      -
   5        $ viewBoxReturn2��51      $��2��62   $��1��6?   $��
5, 5, 5, 6q�6O   $	��Top=�6c   $y�	Collapsed=�6{   .��52      �� -   5        $
 
btnReturn2��52      $��Return��6-   $��18(�6>   
�������
�����p�$��
UltraBlack"�6v   
�������$��3q�53   1   $��
0, 5, 0, 5q�6E   $	��255��6Y   $��50��6h   $	��400��6w   $	��130��6�   6�   54      56      57      58      