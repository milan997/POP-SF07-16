   M S B A M L   `   `   `  ����J  FPOP-SF07-16-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POP_SF07_16_GUI.GUIPOP_SF07_16_GUI.GUI  5   	   %    POP_SF07_16_GUI.GUI.SalonWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POP_SF07_16_GUI.GUI     5   	     � Title$  SalonWindow��5   	   $	��300��6   $	��600��6*   $��14(�66    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��1* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5        $��lbNaziv��5      $��0��5      $��0��6    $��Right=�5      $��Bottom=�6,   $��Naziv: ��5      �� 5   
   -   5        $��tbNaziv��5      $��1��5      $��0��6"   $��Bottom=�6/   $��Stretch=�5      ��5      ��  �� Path$ Naziv��� 5    
   -   5        $��lbAdresa��5"      $��0��5       $��1��6    $��Right=�5!      $��Bottom=�6,   $��Adresa: ��5"       �� 5#   
   -   5        $��tbAdresa��5$      $��1��5#      $��1��6"   $��Bottom=�6/   $��Stretch=�5$       ��5%      �� $ Adresa��� 5'   
   -   5        $��	lbTelefon��5)      $��0��5'      $��2��6    $��Right=�5(      $��Bottom=�6,   $��	Telefon: ��5)   !   �� 5*   
   -   5        $��	tbTelefon��5+      $��1��5*      $��2��6"   $��Bottom=�6/   $��Stretch=�5+   !   ��5,      �� $ Telefon��� 5.   
   -   5        $��lbEmail��50      $��0��5.      $��3��6    $��Right=�5/      $��Bottom=�6,   $��Email: ��50      �� 51   
   -   5        $��tbEmail��52      $��1��51      $��3��6"   $��Bottom=�6/   $��Stretch=�52      ��53      �� $ Email��� 55   
   -	   5        $��lbWebAdresa��57      $��2��55      $��0��6    $��Right=�56      $��Bottom=�6,   $��Web Adresa: ��57   #   �� 58   
   -
   5        $��tbWebAdresa��59      $��3��58      $��0��6"   $��Bottom=�6/   $��Stretch=�59   #   ��5:      �� $ 	WebAdresa��� 5<   
   -   5        $��lbPIB��5>      $��2��5<      $��1��6    $��Right=�5=      $��Bottom=�6,   $��PIB: ��5>      �� 5?   
   -   5        $��tbPIB��5@      $��3��5?      $��1��6"   $��Bottom=�6/   $��Stretch=�5@      ��5A      �� $	 Pib��� 5C   
   -   5        $��lbMaticniBroj��5E      $��2��5C      $��2��6    $��Right=�5D      $��Bottom=�6,   $��Maticni broj: ��5E   %   �� 5F   
   -   5        $��tbMaticniBroj��5G      $��3��5F      $��2��6"   $��Bottom=�6/   $��Stretch=�5G   %   ��5H      �� $ MaticniBroj��� 5J   
   -   5        $��lbBrojRacuna��5L      $��2��5J      $��3��6    $��Right=�5K      $��Bottom=�6,   $��Broj racuna: ��5L   $   �� 5M   
   -   5        $��tbBrojRacuna��5N      $��3��5M      $��3��6"   $��Bottom=�6/   $��Stretch=�5N   $   ��5O      �� $ BrRacuna��� 5Q   
   -   5        $��	btPotvrdi��5S      $��3��5Q      $��4��6!   $��Center=�5R      $��Center=�6-   $��Potvrdi��5S   !   $��28��5T   (   $	��165��65    �� 	IsDefault . 5U      �� 5V   
   -   5        $��btOtkazi��5X      $��4��5V      $��5��6!   $��Center=�5W      $��Center=�6-   $��Otkazi��5X       $��28��5Y   '   $	��165��64   5Z      5[      