   M S B A M L   `   `   `  ����M  IDoDuongDangKhoaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DoDuongDangKhoaWPFDoDuongDangKhoaWPF  5   	   "    DoDuongDangKhoaWPF.RoomPopup   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:DoDuongDangKhoaWPF     5   	     � Title$  
Room Popup��5   	   $	��370��6   $	��545��6)    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � $
��1254��6   $	��662��6   .+�5   
   �� $��Room ID:��6   $
��Left=�6#   $��	10,10,0,0q�6>   $	��Top=�6Q   �� 5   
   -   5        $��	txtRoomId��5   ;    �� 
IsReadOnly$
 True��6   $��10,36,994,599q�6$   6;   �� 5   
   $��Room Number:��6   $
��Left=�6'   $��	10,63,0,0q�6B   $	��Top=�6U   �� 5   
   -   5        $��txtRoomNumber��5   )   $��10,94,994,541q�6   6)   �� 5   
   $��Room Detail Description:��6   $
��Left=�63   $��
10,121,0,0q�6N   $	��Top=�6b   �� 5   
   -   5        $��txtRoomDetailDescription��5   >    �� TextWrapping$
 Wrap=�6   $��10,152,994,455q�6&   6>   �� 5   
   $��Room Max Capacity:��6   $
��Left=�6-   $��
10,212,0,0q�6H   $	��Top=�6\    J� RenderTransformOrigin$ 0.483,1.347&�6t   �� 5   
   -   5        $��txtRoomMaxCapacity��5   *   $��10,243,994,392q�6   6*   �� 5   
   $��RoomType Name:��6   $
��Left=�6)   $��
265,10,0,0q�6D   $	��Top=�6X   �� 5   
   -   5        $��cbbRoomTypeName��5   +   $��275,36,729,599q�6   6+   �� 5   
   $��Room Status:��6   $
��Left=�6'   $��
265,68,0,0q�6B   $	��Top=�6V   �� 5   
   -   5        $��txtRoomStatus��5   *   $��275,94,729,541q�6   6*   �� 5   
   $��Room Price Per Day:��6   $
��Left=�6.   $��275,121,0,0q�6I   $	��Top=�6^   �� 5   
   -   5        $��txtRoomPricePerDay��5   +   $��275,148,729,487q�6   6+   �� 5   
   -   5        $��btnAddUpdate��5   $   $��Add Room��6   $
��Left=�6S   $��216,286,0,341q�6n   $	��101��6�   5      5      