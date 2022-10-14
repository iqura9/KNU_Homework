// .NET 6.0

using ConsoleApp1;

string desc = "The Dnieper or Dnipro is one of the major " +
              "transboundary rivers of Europe, rising in the Valdai Hills near Smolensk, " +
              "russia, before flowing through belarus and Ukraine to the Black Sea. " +
              "It is the longest river of Ukraine and Belarus and the fourth-longest river in Europe, after the Volga, Danube, and Ural rivers.";
River dnirpo = new River("55°52′18″ пн. ш.", "33°43′27″ сх. д.", "Dnipro", desc, 1670, 2201);
dnirpo.GetInfo();
string descHoverla =
    "Mount Hoverla, at 2,061 metres, is the highest mountain in Ukraine and part of the Carpathian Mountains. " +
    "The mountain is located in the Eastern Beskids, in the Chornohora region. " +
    "The slopes are covered with beech and spruce forests, above which there is a belt of sub-alpine meadows called polonyna in Ukrainian.";
Mountain hoverla = new Mountain("48.1602° N", "24.5000° E", "Hoverla", descHoverla, 2061);
hoverla.GetInfo();