   M S B A M L   `   `   `  ����V  RSteganografia-implementacja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Steganografia_implementacjaSteganografia_implementacja  5   	   3    -Steganografia_implementacja.Zasada_działania   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Steganografia_implementacja     5   	     � Title$  Zasada_działania��5   	   $	��302��6"   $��661.106��6/   .��5	      � .+�5
   
   �� $
��Left=�6   $��78��6-   $��	29,55,0,0q�69    �� TextWrapping$
 Wrap=�6L   $����	Działanie algorytmu najmniej znaczączego bitu polega na zmianie najmniej znaczącego bitu słowa opisującego dany pixel. Jej wynik zależy ściśle od liczby bitów przeznaczonych do zapisu pojedynczego piksela: im więcej bitów opisuje dany piksel, tym mniejsze znaczenie ma dla globalnego odczucia odbiorcy modyfikacja jednego lub kilku ostatnich bitów.��6`   $	��Top=�6�  $	��602��6�  
�������6�  �� 5   
   $����Źródło:  "Ochrona danych i zabezpieczenia w systemach teleinformatycznych", pod red. Janusza Stokłosy, Wyd. 2 popr. , Poznań, 
	Wydawnictwo Politechniki Poznańskiej, 2005, ISBN 83-7143-478-2.��6   $
��Left=�6�   $��
38,230,0,0q�6  $	��Top=�6  $	��607��63  $��36��6?  $��9(�6K  �� 5   
   -   5        $
��Left=�5      $��23��6-   $��	29,19,0,0q�69   $
 Wrap=�6L   $.��(Algorytm LSB (najmniej znaczącego bitu)��6`   $	��Top=�6�   $	��266��6�   $��16(�6�   
�������6�   �� 5   
   $����
Wiedomość umieszczana jest poziomo. Na pierwszych 8 bitach ukryta jest długość całej wiadomości. Możliwy 
jest wybór początku osadzania wiadomości. W przypadku zbyt długiej wiadomości lub wybrania początku
 osadzania, który uniemożliwi ukrycie wiadomości, na ekranie pojawia się okno informujące o zaistniałej sytuacji.
��6   $
��Left=�6�  $��32,143,-153,0q�6�  $	��Top=�6�  $	��774��6�  $��84��6�  �� 5   
   -   5        $
��Left=�5      $��23��6-   $��
31,131,0,0q�69   $
 Wrap=�6M   $��Specyfikacja założeń:��6a   $	��Top=�6~   $	��266��6�   $��16(�6�   
�������6�   5      5      