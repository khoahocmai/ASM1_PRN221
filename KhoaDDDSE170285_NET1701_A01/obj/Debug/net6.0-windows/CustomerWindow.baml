   M S B A M L   `   `   `  ����M  IDoDuongDangKhoaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DoDuongDangKhoaWPFDoDuongDangKhoaWPF  5   	   '    !DoDuongDangKhoaWPF.CustomerWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:DoDuongDangKhoaWPF     5   	     � Title$  Customer Window��5   	   $	��567��6!   $	��773��6.    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � $
��1254��6   $	��662��6   .+�5   
   �� $��	Fullname:��6   $
��Left=�6$   $��	10,10,0,0q�6?   $	��Top=�6R   �� 5   
   -   5        $��txtCusFullname��5   ;    �� 
IsReadOnly$
 True��6   $��10,36,845,599q�6$   6;   �� 5   
   $��
Telephone:��6   $
��Left=�6%   $��	10,68,0,0q�6@   $	��Top=�6S   �� 5   
   -   5        $��txtCusPhone��5   ;   $
 True��6   $��11,99,845,536q�6$   6;   �� 5   
   $��Email Address:��6   $
��Left=�6)   $��
10,131,0,0q�6D   $	��Top=�6X   �� 5   
   -   5        $��txtCusEmail��5   <   $
 True��6   $��10,162,845,473q�6$   6<   �� 5   
   $��Day of Birth:��6   $
��Left=�6(   $��
10,194,0,0q�6C   $	��Top=�6W   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpCusDOB��5   '   ${�False��6   $��10,225,845,410q�67   �� 5   
   $��	Password:��6   $
��Left=�6$   $��
10,257,0,0q�6?   $	��Top=�6S   G� 5   
   -   5        $��
pbPassword��5   �   ${�False��6   $
��Left=�6(   $��
10,288,0,0q�6C   $	��Top=�6W   $	��399��6o   $��27��6{   6�   �� 5   
   -   5        $��btnUpdateInfo��5   �   $��Update Info��6   $
��Left=�6'   $��
475,34,0,0q�6B   $	��Top=�6V   $��32��6n   $	��104��6z   6�   �� 5   
   -   5        $��	btnLogout��5   �   $��Logout��6   $
��Left=�6"   $��
627,36,0,0q�6=   $	��Top=�6Q   $��32��6i   $	��104��6u   6�   �� 5   
   $"��Booking reservation history:��6   $
��Left=�67   $��
10,349,0,0q�6R   $	��Top=�6f   $��18(�6~   �� 5   
   -   5        $��bookingListView��5      $��10,398,492,124q�6*    �� View 5      �� 5      .P�5      �� $��Booking Reservation ID��6%    �� Width$	 188��6{    �� DisplayMemberBinding 6E   �� *BookingReservationId+6{   �� 5      $��Booking Date��6%   $	 188��6h    6;   �� *BookingDate+6h   �� 5       $��Total Price��6%   $	 188��6f    6:   �� *
TotalPrice+6f   �� 5!      $��Booking Status��6%   $	 188��6l    6=   �� *BookingStatus+6l   5"      5$      5&      5'      