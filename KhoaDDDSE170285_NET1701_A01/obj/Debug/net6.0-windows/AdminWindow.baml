   M S B A M L   `   `   `  ����M  IDoDuongDangKhoaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DoDuongDangKhoaWPFDoDuongDangKhoaWPF  5   	   $    DoDuongDangKhoaWPF.AdminWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:DoDuongDangKhoaWPF     5   	     � Title$  Admin Window��5   	   $	��567��6   $	��773��6+    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � .+�5   
   �� .@�5      �� $��Customer Management��6   .��5      � $
��Left=�6   $
��1254��62   $	��662��6?   $��9,0,0,0q�6L   .+�5      �� $��Customer ID:��6   $
��Left=�63   $��	10,10,0,0q�6N   $	��Top=�6a   �� 5      -   5        $��txtCusId��5   c    �� 
IsReadOnly$
 True��6   $��10,36,903,599q�6L   ��60   �� *
CustomerId+ � DataContext 6s   �� *SelectedItem+ �� ElementName$ CustomerListView���� 5      $��Customer Fullname:��6   $
��Left=�69   $��	10,63,0,0q�6T   $	��Top=�6g   �� 5      -   5        $��txtCusFullname��5   i   $
 True��6   $��10,94,903,541q�6R   ��60   �� *CustomerFullName+ 6   �� *SelectedItem+$ CustomerListView���� 5      $��Customer Phone:��6   $
��Left=�66   $��
10,121,0,0q�6Q   $	��Top=�6e   �� 5      -   5        $��txtCusPhone��5   c   $
 True��6   $��10,152,903,483q�6K   ��60   �� *	Telephone+ 6v   �� *SelectedItem+$ CustomerListView���� 5      $��Customer Email:��6   $
��Left=�66   $��
10,179,0,0q�6Q   $	��Top=�6e   �� 5      -   5        $��txtCusEmail��5   f   $
 True��6   $��10,210,903,425q�6N   ��60   �� *EmailAddress+ 6y   �� *SelectedItem+$ CustomerListView���� 5      $��Customer DOB:��6   $
��Left=�64   $��	423,5,0,0q�6O   $	��Top=�6b   (  "System.Windows.Controls.DatePicker  5      -   5        $��dpCusDOB��5   �   ${�False��6!   $��423,36,513,599q�6�      Text 63   �� *CustomerBirthday+ 6U   �� *SelectedItem+$ CustomerListView��6�   �� 5      $��Customer Status:��6   $
��Left=�67   $��
423,76,0,0q�6R   $	��Top=�6f   ]� 5      $��431,108,513,522q�6    .+�5      	� -   5         	�Name$ 
rbtnActive��5   H   $��Active��6&    d� 	IsChecked$
 TrueY�67   $
��Left=�6\   $	��129��6r   $��20��6~   	� 5      -   5        $ 
rbtnDelete��5   I   $��Delete��6&   $ FalseY�67   $��Right=�6]   $��20��6t   5      �� 5      -   5        $��btnCusRefress��5   T   $��Refresh��6   $	��100��6/   $��49,271,1105,354q�6;   6i   �� 5       -	   5        $��btnCusCreate��5    S   $��Create��6   $	��100��6.   $��177,271,977,354q�6:   6g   �� 5!      -
   5        $��
btnCusEdit��5!   Q   $
��Edit��6   $	��100��6,   $��314,271,840,354q�68   6c   �� 5"      -   5        $��btnCusDelete��5"   S   $��Delete��6   $	��100��6.   $��454,271,700,354q�6:   6g   �� 5$      $��Search:��6    $��431,152,732,484q�6/   �� 5%       �� Orientation$ 
Horizontal=�6!   $��431,180,577,455q�6:   .+�5&      	� -   5        $��rbtnFullname��5&   7   $
 TrueY�6&   $��Fullname��6K   	 	� 	GroupName$	 SearchCriteria��6^   $��0,0,10,0q�6y   	� 5'      -   5        $��	rbtnEmail��5'   &   $��Email��67   $	 SearchCriteria��6G   $��0,0,10,0q�6b   	� 5(      -   5        $��
rbtnStatus��5(   &   $��Status��68   $	 SearchCriteria��6I   5)      �� 5*      -   5        $��	txtSearch��5*      $��423,210,513,426q�6/   $ Enter search term��6H   �� 5+      -   5        $��btnSearchCus��5+   S   $��Search��6   $	��100��6.   $��641,176,513,461q�6:   6g   �� 5.      -   5        $��CustomerListView��5.   7   $��10,331,513,156q�6   
 �� View
 5/      �� 50      .P�51   "   �� $��Customer ID��61    �� Width$ 80��6w    �� DisplayMemberBinding 6F   ��  �� Path$ 
CustomerId�6w   �� 52   "   $��	Full Name��61   $	 130��6{    6D   �� $ CustomerFullName�6{   �� 53   "   $��	Telephone��61   $ 80��6t    6D   �� $ 	Telephone�6t   �� 54   "   $��Email Address��61   $	 210��6{    6H   �� $ EmailAddress�6{   �� 55   "   $��Birthday��61   $	 120��6�    6C   �� $ CustomerBirthday� �� StringFormat$ {0:MM/dd/yyyy}��6�   �� 56   "   $��Status��61   $ 70��6v    6A   �� $ CustomerStatus�6v   57      59      �� 5:      -   5        $��	btnLogout��5:   �   $��Log out��6   $
��Left=�6/   $��643,271,0,0q�6J   $	��Top=�6_   $��37��6w   $��98��6�   6�   5;      5<      �� 5?      $��Room Management��6   .��5@      � $
��Left=�6   $
��1254��62   $	��662��6?   $��9,0,0,0q�6L   .+�5A      �� $��Room ID:��6   $
��Left=�6/   $��	10,10,0,0q�6J   $	��Top=�6]   �� 5B      -   5        $��	txtRoomId��5B   _   $
 True��6   $��10,36,903,599q�6H   ��60   �� *RoomId+ 6p   �� *SelectedItem+$ RoomListView���� 5C      $��Room Number:��6   $
��Left=�63   $��	10,63,0,0q�6N   $	��Top=�6a   �� 5D      -   5        $��txtRoomNumber��5D   c   $
 True��6   $��10,94,903,541q�6L   ��60   �� *
RoomNumber+ 6x   �� *SelectedItem+$ RoomListView���� 5E      $��Room Detail Description:��6   $
��Left=�6?   $��
10,121,0,0q�6Z   $	��Top=�6n   �� 5F      -   5        $��txtRoomDetailDescription��5F   �   $
 True��6    �� TextWrapping$
 Wrap=�60   $��10,152,903,455q�6k   ��6D   �� *RoomDetailDescription+ 6�   �� *SelectedItem+$ RoomListView���� 5G      $��Room Max Capacity:��6   $
��Left=�69   $��
10,212,0,0q�6T   $	��Top=�6h    J� RenderTransformOrigin$ 0.483,1.347&�6�   �� 5H      -   5        $��txtRoomMaxCapacity��5H   i   $
 True��6   $��10,243,903,393q�6Q   ��60   �� *RoomMaxCapacity+ 6�   �� *SelectedItem+$ RoomListView���� 5I      $��RoomType Name:��6   $
��Left=�65   $��
398,10,0,0q�6P   $	��Top=�6d   �� 5J      -   5        $��txtRoomTypeName��5J   H   $
 True��6   $��398,36,515,599q�60    6_   �� *SelectedItem+$ RoomListView���� 5K      $��Room Status:��6   $
��Left=�63   $��
398,68,0,0q�6N   $	��Top=�6b   �� 5L      -   5        $��txtRoomStatus��5L   d   $
 True��6   $��398,94,515,541q�6L   ��60   �� *
RoomStatus+ 6y   �� *SelectedItem+$ RoomListView���� 5M      $��Room Price Per Day:��6   $
��Left=�6:   $��398,121,0,0q�6U   $	��Top=�6j   �� 5N      -   5        $��txtRoomPricePerDay��5N   j   $
 True��6   $��398,152,515,482q�6Q   ��60   �� *RoomPricePerDay+ 6�   �� *SelectedItem+$ RoomListView���� 5P      -   5        $��btnRoomRefress��5P   T   $��Refresh��6   $	��100��6/   $��40,285,1114,340q�6;   6j   �� 5Q      -   5        $��btnRoomCreate��5Q   S   $��Create��6   $	��100��6.   $��200,285,954,340q�6:   6h   �� 5R      -   5        $��btnRoomEdit��5R   Q   $
��Edit��6   $	��100��6,   $��364,285,790,340q�68   6d   �� 5S      -   5        $��btnRoomDelete��5S   S   $��Delete��6   $	��100��6.   $��527,285,627,340q�6:   6h   �� 5U      $��Search:��6    $��398,185,765,451q�6/   �� 5V      $ 
Horizontal=�6!   $��398,211,508,424q�6:   .+�5W      	� -   5        $��rbtnRoomNumber��5W   7   $
 TrueY�6&   $��
RoomNumber��6M   $	 SearchCriteria��6b   $��0,0,10,0q�6}   	� 5X      -   5        $��rbtnRoomMaxCapacity��5X   &   $��RoomMaxCapacity��6A   $	 SearchCriteria��6[   $��0,0,10,0q�6v   	� 5Y      -    5        $��rbtnRoomPricePerDay��5Y   &   $��RoomPricePerDay��6A   $	 SearchCriteria��6[   $	��118��6v   5Z      �� 5[      -!   5        $��txtSearchRoom��5[      $��398,243,627,393q�63   $ Enter search term��6L   �� 5\      -"   5        $��btnSearchRoom��5\   S   $��Search��6   $	��100��6.   $��639,243,515,394q�6:   6h   �� 5^      -#   5        $��RoomListView��5^   7   $��10,338,513,149q�6   
 5_      �� 5`      .P�5a   "   �� $��Room ID��61   $ 60��6o    6B   �� $ RoomId�6o   �� 5b   "   $��Room Number��61   $ 90��6w    6F   �� $ 
RoomNumber�6w   �� 5c   "   $��Room Detail Description��61   $	 140��6�    6R   �� $ RoomDetailDescription�6�   �� 5d   "   $��Room Max Capacity��61   $	 120��6�    6L   �� $ RoomMaxCapacity�6�   �� 5e   "   $��Room Type Id��61   $	 120��6x    6G   �� $ 
RoomTypeId�6x   �� 5f   "   $��Room Status��61   $ 80��6w    6F   �� $ 
RoomStatus�6w   �� 5g   "   $��Room Price Per Day��61   $	 110��6�    6M   �� $ RoomPricePerDay�6�   5h      5j      5k      5l      �� 5o      $��Report Management��6   .��5p      � $
��1254��6   $	��662��6$   .+�5q      �� $��Start Date:��6   $
��Left=�62   $��	10,19,0,0q�6M   $	��Top=�6`   $��30��6x   $��80��6�     5r      -$   5        $��dpStartDate��5r   [   $��95,19,959,613q�6D      SelectedDate 6!   �� *	StartDate+6[   �� 5s      $��	End Date:��6   $
��Left=�60   $��
323,21,0,0q�6K   $	��Top=�6_     5t      -%   5        $��	dpEndDate��5t   Z   $��404,19,650,613q�6B    6!   �� *	EndDate+6Z   �� 5u      -&   5        $��	btnReport��5u   7   $��Generate Report��6   $��628,19,512,613q�6r   ��6H   �� *GenerateReportCommand+6�   �� 5w      -'   5        $��ReportBookReserListView��5w      $��10,77,512,399q�6>   
 5x      �� 5y      .P�5z   "   �� $��Booking Date��61   $	 100��6�    6G   �� *BookingDate+$ {0:MM/dd/yyyy}��6�   �� 5{   "   $��Customer Name��61   $	 150��6v    6H   �� *CustomerName+6v   �� 5|   "   $��Total Price��61   $	 100��6r    6F   �� *
TotalPrice+6r   �� 5}   "   $��Booking Status��61   $	 100��6x    6I   �� *BookingStatus+6x   5~      5�      �� 5�      -(   5        $��ReportBookDetailListView��5�      $��10,282,512,194q�6?   
 5�      �� 5�      .P�5�   "   �� $��Room Number��61   $	 150��6r    6F   �� *
RoomNumber+6r   �� 5�   "   $��
Start Date��61   $	 100��6�    6E   �� *	StartDate+$ {0:MM/dd/yyyy}��6�   �� 5�   "   $��End Date��61   $	 100��6�    6C   �� *	EndDate+$ {0:MM/dd/yyyy}��6�   �� 5�   "   $��Actual Price��61   $	 120��6t    6G   �� *ActualPrice+6t   5�      5�      5�      5�      5�      5�      5�      