   M S B A M L   `   `   `  ����N  JLibraryAssigmentWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:LibraryAssigmentWPF.UserControls LibraryAssigmentWPF.UserControls  5   	   $    LibraryAssigmentWPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   GuserControls.clr-namespace:LibraryAssigmentWPF.UserControls     5   	     � Title$  	Chitalnya��5   	   $	��600��6   $
��1200��6(    � WindowStartupLocation$ CenterScreen=�65    � WindowState$ 	Maximized=�6Z   .��5
      � .+�5   
   � -   5         �Name$ MainMenu��5       � RowDefinitions 5      �� 5      $	��.2* �6    �� 5      .+�5      � $��0��6   
�������.+�5      (� .��5      �� $#��Ваша Библиотека��6    $��50(�68   $��David)�6F   $��Center=�6Y   $��Center=�6t   
�������$
��Bold"�6�   5      5      � 5      $��1��6   
���OO/� 5      �� 5      �� 5      �� 5      .+�5      � $��0��6   .+�5      (� .��5      �� -   5         ��Name$ 
btnManager��5   !   $��Менеджер��65   $	��130��6H   $��70��6W   $	��500��6f   $	��330��6u   $��20(�6�   
�������
�����p�$��
ultraBlack"�5      
�������$��3q�6O   $��	0,10,0,10q�6c   6v   5      5       � 5!      $��1��6   .+�5"      �� -   5        $ 	btnWorker��5"      $��Работник��60   $	��130��6C   $��70��6R   $	��300��6a   $	��330��6p   $��30(�6�   
�������
�����p�$��
ultraBlack"�5#      
�������$��6q�6O   $��455,24,455,23q�6c   6z   5$      � 5%      $��2��6   .+�5&      (� .��5'      �� -   5        $ btnExit��5'   !   $��
Выход��62   $	��130��6B   $��70��6Q   $	��500��6`   $	��330��6o   $��20(�6   
�������
�����p�$��
ultraBlack"�5(      
�������$��3q�6N   $��	0,10,0,10q�6b   6u   5)      5*      5+      5,      � 5-   
   -   5        $ managerGrid��5-      $y�	Collapsed=�6$   .+�5.      .   (LibraryAssigmentWPF.UserControls.Manager  -   5          Name$ ManagerUserControl��5.   #   5/      � 50   
   -   5        $ addBookGrid��50      $y�	Collapsed=�6$   .+�51      .   (LibraryAssigmentWPF.UserControls.AddBook  -   5          Name$ AddBookUserControl��51   #   52      � 53   
   -	   5        $ 
workerGrid��53      $y�	Collapsed=�6#   .+�54      -   'LibraryAssigmentWPF.UserControls.Worker  -
   5          Name$ WorkerUserControl��54   "   55      � 56   
   -   5        $ editBookGrid��56      $y�	Collapsed=�6%   .+�57      /   )LibraryAssigmentWPF.UserControls.EditBook  -   5        	  Name$	 EditBookUserControl��57   $   58      � 59   
   -   5        $ editBookGrid2��59      $y�	Collapsed=�6&   .+�5:      0   *LibraryAssigmentWPF.UserControls.EditBook2  -   5        
  Name$
 EditBookUserControl2��5:   %   5;      � 5<   
   -   5        $ RemoveBookGrid��5<      $y�	Collapsed=�6'   .+�5=      1   +LibraryAssigmentWPF.UserControls.RemoveBook  -   5          Name$ RemoveBookUserControl��5=   &   5>      � 5@   
   -   5        $ ShowBooksGrid��5@      $y�	Collapsed=�6&   .+�5A      0   *LibraryAssigmentWPF.UserControls.ShowBooks  -   5          Name$ ShowBooksUserControl��5A   %   5B      � 5C   
   -   5        $ ShowAvailableItemsGrid��5C      $y�	Collapsed=�6/   .+�5D      9   3LibraryAssigmentWPF.UserControls.ShowAvailableItems  -   5          Name$# ShowAvailableItemsUserControl��5D   .   5E      � 5F   
   -   5        $ AddJournalGrid��5F      $y�	Collapsed=�6'   .+�5G      1	   +LibraryAssigmentWPF.UserControls.AddJournal	  -   5         	 Name$ AddJournalGridUserControl��5G   &   5H      � 5I   
   -   5        $ EditJournalGrid��5I      $y�	Collapsed=�6(   .+�5J      2
   ,LibraryAssigmentWPF.UserControls.EditJournal
  -   5         
 Name$ EditJournalUserControl��5J   '   5K      � 5L   
   -   5        $ EditJournalGrid2��5L      $y�	Collapsed=�6)   .+�5M      3   -LibraryAssigmentWPF.UserControls.EditJournal2  -   5          Name$ EditJournalUserControl2��5M   (   5N      � 5O   
   -   5        $ RemoveJournalGrid��5O      $y�	Collapsed=�6*   .+�5P      4   .LibraryAssigmentWPF.UserControls.RemoveJournal  -   5          Name$ RemoveJournalUserControl��5P   )   5Q      � 5R   
   -   5        $ ShowJournalsGrid��5R      $y�	Collapsed=�6)   .+�5S      3   -LibraryAssigmentWPF.UserControls.ShowJournals  -   5          Name$ ShowJournalsUserControl��5S   (   5T      � 5U   
   -   5        $ SellItemsGrid��5U      $y�	Collapsed=�6&   .+�5V      0   *LibraryAssigmentWPF.UserControls.SellItems  -    5          Name$ SellItemsControl��5V   %   5W      � 5X   
   -!   5        $ ReceiptsGrid��5X      $y�	Collapsed=�6%   .+�5Y      /   )LibraryAssigmentWPF.UserControls.Receipts  -"   5          Name$ ReceiptsControl��5Y   $   5Z      � 5[   
   -#   5        $ AddCustomerGrid��5[      $y�	Collapsed=�6(   .+�5\      2   ,LibraryAssigmentWPF.UserControls.AddCustomer  -$   5          Name$ AddCustomerControl��5\   '   5]      � 5^   
   -%   5        $ RemoveCustomerGrid��5^      $y�	Collapsed=�6+   .+�5_      5   /LibraryAssigmentWPF.UserControls.RemoveCustomer  -&   5          Name$ RemoveCustomerControl��5_   *   5`      � 5a   
   -'   5        $ ManageExceptionsGrid��5a      $y�	Collapsed=�6-   .+�5b      7   1LibraryAssigmentWPF.UserControls.ManageExceptions  -(   5          Name$ ManageExceptionControl��5b   ,   5c      � 5d   
   -)   5        $ ShowClubCustomersGrid��5d      $y�	Collapsed=�6.   .+�5e      8   2LibraryAssigmentWPF.UserControls.ShowClubCustomers  -*   5          Name$ ShowClubCustomersControl��5e   -   5f      � 5g   
   -+   5        $ AddComicsGrid��5g      $y�	Collapsed=�6&   .+�5h      0   *LibraryAssigmentWPF.UserControls.AddComics  -,   5          Name$ AddComicsUserControl��5h   %   5i      � 5j   
   --   5        $ EditComicsGrid��5j      $y�	Collapsed=�6'   .+�5k      1   +LibraryAssigmentWPF.UserControls.EditComics  -.   5          Name$ EditComicsUserControl��5k   &   5l      � 5m   
   -/   5        $ EditComicsGrid2��5m      $y�	Collapsed=�6(   .+�5n      2   ,LibraryAssigmentWPF.UserControls.EditComics2  -0   5          Name$ EditComicsUserControl2��5n   '   5o      � 5p   
   -1   5        $ RemoveComicsGrid��5p      $y�	Collapsed=�6)   .+�5q      3   -LibraryAssigmentWPF.UserControls.RemoveComics  -2   5          Name$ RemoveComicsUserControl��5q   (   5r      � 5s   
   -3   5        $ ShowComicsGrid��5s      $y�	Collapsed=�6'   .+�5t      1   +LibraryAssigmentWPF.UserControls.ShowComics  -4   5          Name$ ShowComicsUserControl��5t   &   5u      5v      5w      