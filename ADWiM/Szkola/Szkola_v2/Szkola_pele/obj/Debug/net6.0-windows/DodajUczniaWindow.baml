   M S B A M L   `   `   `  ????F  BSzkola_pele, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Szkola_peleSzkola_pele  5   	   #    Szkola_pele.DodajUczniaWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Szkola_pele     5   	     ? Title$  Dodaj Ucznia??5   	   $	??534??6   $	??844??6+   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5       ? ColumnDefinitions 5   
   ?? 5      $??1* ?6   ?? 5      $??6* ?6   .+?5   
   ?? $??15(?6   $??2??6   $??0.5 10q?62   .??6B   Dodaj Ucznia:6Q   ?? 5   
   $??1??6   .??6   Imię:6%   ?? 5   
   -   5        $??imie_ui??5      $??1??6!   $??1??6.    ?? AcceptsReturn$
 True??6>    ?? TextWrapping$ WrapWithOverflow=?6S   ?? 5   
   $??2??6   .??6   	Nazwisko:6(   ?? 5    
   -   5        $??nazwisko_ui??5       $??2??6%   $??1??62   $
 True??6B   $ WrapWithOverflow=?6W   ?? 5"   
   $??3??6   .??6   Wiek:6$   ?? 5#   
   -   5        $??wiek_ui??5#      $??3??6!   $??1??6.   $
 True??6>   $ WrapWithOverflow=?6S   ?? 5%   
   $??4??6   .??6   Inteligencja:6,   ?? 5&   
   -   5        $??inteligencja_ui??5&      $??4??6)   $??1??66   $
 True??6F   $ WrapWithOverflow=?6[   ?? 5(   
   $??5??6   .??6   Siła:6$   ?? 5)   
   -   5        $??sila_ui??5)      $??5??6!   $??1??6.   $
 True??6>   $ WrapWithOverflow=?6S   ?? 5+   
   $??6??6   .??6   	Zwinnosc:6(   ?? 5,   
   -   5        $??zwinnosc_ui??5,      $??6??6%   $??1??62   $
 True??6B   $ WrapWithOverflow=?6W   ?? 5.   
   $??7??6   .??6   	Charyzma:6(   ?? 5/   
   -   5        $??charyzma_ui??5/      $??7??6%   $??1??62   $
 True??6B   $ WrapWithOverflow=?6W   ? 51   
   $??8??6   $??2??6    52      ?? 53      $??1* ?6#   ?? 54      $??1* ?6#   ?? 55      $??5* ?6#   .+?57      ?? -   5        $??	zapisz_ui??57      $??Zapisz??6&   $??13q?67   6C   ?? 58      -	   5        $??	anuluj_ui??58      $??Anuluj??6&   $??1??67   $??13q?6[   59      5:      5;      