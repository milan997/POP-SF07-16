   M S B A M L   `   `   `  ����J  FPOP-SF07-16-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POP_SF07_16_GUI.GUIPOP_SF07_16_GUI.GUI  5   	   2    ,POP_SF07_16_GUI.GUI.DodajDodatnaUslugaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POP_SF07_16_GUI.GUI     5   	     � Title$  DodajDodatnaUslugaWindow��5   	   $	��420��6*   $	��600��67    � WindowStartupLocation$ CenterScreen=�6C   $��14(�6h   .��5	      �  � RowDefinitions 5
   
   �� 5      $��6* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgDodatnaUsluga��5      $��0��6*   $��Stretch=�5      $��Stretch=�61   $��
5, 5, 5, 5q�5         
IsReadOnly .    CanUserAddRows .   �� SelectedItem 5      ��  �� Path$ DodatnaUsluga�5      �� 5   
   -   5        $��
lbKolicina��5      $��Kolicina��6"   $��1��65   $
��Left=�5      $��Bottom=�6+   $��50��5      �� 5   
   -   5        $��
tbKolicina��5      $��1��6$   $��Stretch=�5      $��Bottom=�60   $��55, 0, 0, 0q�5      ��5      �� $ Kolicina�5      �� 5   
   -   5        $��
btnPotvrdi��5   :   $��2��6   $��Right=�6   $��45��6e   $��35��6p   .��6|   	Potvrdi6�   �� 5    
   -   5        $��	btnOtkazi��5    :   $��2��6   $��Right=�6   $��0,0,50,0q�6c   $��35��6u   .��6�   Otkazi6�   5!      5"      