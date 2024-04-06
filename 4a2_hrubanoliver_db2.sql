-- phpMyAdmin SQL Dump
-- version 4.9.4
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Apr 06, 2024 at 10:04 AM
-- Server version: 10.3.25-MariaDB-0+deb10u1
-- PHP Version: 5.6.36-0+deb8u1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `4a2_hrubanoliver_db2`
--

-- --------------------------------------------------------

--
-- Table structure for table `AdminSellers`
--

CREATE TABLE `AdminSellers` (
  `ID` int(11) NOT NULL,
  `ImagePath` varchar(100) COLLATE utf8_czech_ci DEFAULT NULL,
  `Type` tinyint(1) NOT NULL,
  `Title` varchar(20) COLLATE utf8_czech_ci NOT NULL,
  `Name` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `Surname` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `Email` varchar(50) COLLATE utf8_czech_ci DEFAULT NULL,
  `Tel` varchar(13) COLLATE utf8_czech_ci NOT NULL,
  `LoginName` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `Password` text COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Dumping data for table `AdminSellers`
--

INSERT INTO `AdminSellers` (`ID`, `ImagePath`, `Type`, `Title`, `Name`, `Surname`, `Email`, `Tel`, `LoginName`, `Password`) VALUES
(1, '\\podklady\\ing1.png', 0, 'Ing', 'Jarmila', 'Vostrá', 'jarmila@seznam.cz', '+4206045096', 'jarmilka', '043a718774c572bd8a25adbeb1bfcd5c0256ae11cecf9f9c3f925d0e52beaf89'),
(2, '\\podklady\\simon.jpg', 1, 'Maturita', 'Šimon', 'Matějíček', 'eineSimonBitte@seznamka.cz', '666666666', 'simon', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92');

-- --------------------------------------------------------

--
-- Table structure for table `Attributes`
--

CREATE TABLE `Attributes` (
  `ID` int(11) NOT NULL,
  `Name` varchar(40) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Dumping data for table `Attributes`
--

INSERT INTO `Attributes` (`ID`, `Name`) VALUES
(1, 'Zahrada'),
(2, 'Stav budovy'),
(3, 'Vlastnictvíí'),
(4, 'Stav bytu'),
(5, 'Užitečná plocha bytu'),
(6, 'Počet podlaží budovy'),
(7, 'Vybavení'),
(8, 'Lodžie'),
(9, 'Připojení k internetu'),
(10, 'Počet podlaží bytu');

-- --------------------------------------------------------

--
-- Table structure for table `AttributesValues`
--

CREATE TABLE `AttributesValues` (
  `ID` int(11) NOT NULL,
  `IDOffer` int(11) NOT NULL,
  `IDAttribute` int(11) NOT NULL,
  `Value` varchar(100) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Dumping data for table `AttributesValues`
--

INSERT INTO `AttributesValues` (`ID`, `IDOffer`, `IDAttribute`, `Value`) VALUES
(1, 1, 1, 'velká'),
(2, 1, 2, 'dobrý'),
(3, 1, 3, 'osobní'),
(4, 1, 4, 'po rekonstrukci'),
(5, 1, 5, '41'),
(6, 1, 6, '8 podlaží'),
(7, 1, 7, '3. NP'),
(8, 1, 8, 'částečně zařízený'),
(9, 1, 9, 'ne'),
(11, 1, 9, 'osos'),
(12, 1, 9, 'osos'),
(17, 15, 1, 'Velka'),
(18, 15, 1, 'V poradku'),
(19, 15, 1, '8'),
(20, 15, 1, 'osos'),
(34, 20, 1, 'osos');

-- --------------------------------------------------------

--
-- Table structure for table `Categories`
--

CREATE TABLE `Categories` (
  `ID` int(11) NOT NULL,
  `Name` varchar(20) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Dumping data for table `Categories`
--

INSERT INTO `Categories` (`ID`, `Name`) VALUES
(1, 'Byty'),
(2, 'Luxusní'),
(3, 'Domy'),
(4, 'Chaty');

-- --------------------------------------------------------

--
-- Table structure for table `Demands`
--

CREATE TABLE `Demands` (
  `ID` int(11) NOT NULL,
  `IDUser` int(11) DEFAULT NULL,
  `IDOffer` int(11) NOT NULL,
  `Name` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `Tel` varchar(15) COLLATE utf8_czech_ci NOT NULL,
  `Email` varchar(30) COLLATE utf8_czech_ci NOT NULL,
  `Message` text COLLATE utf8_czech_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Dumping data for table `Demands`
--

INSERT INTO `Demands` (`ID`, `IDUser`, `IDOffer`, `Name`, `Tel`, `Email`, `Message`) VALUES
(12, NULL, 2, '7777', '123456789', 'FDSA@sdafasd', 'gsda'),
(13, NULL, 3, '7777', '123456789', 'FDSA@sdafasd', 'sfadf'),
(14, NULL, 3, '7777', '123456789', 'FDSA@sdafasd', 'fas'),
(15, NULL, 3, '7777', '123456789', 'FDSA@sdafasd', 'j'),
(16, NULL, 3, 'oss', '123456789', 'FDSA@sdafasd', 'k'),
(19, NULL, 3, 'oss', '123456789', 'FDSA@sdafasd', 'f'),
(20, NULL, 3, 'oss', '123456789', 'FDSA@sdafasd', 'f'),
(21, 7, 3, 'test', '123456789', 'test@test.cz', '4654654'),
(22, 7, 3, 'test', '123456789', 'test@test.cz', 'test'),
(23, NULL, 17, 'fff', '666666666', 'dfsa@fds', 'fdsa'),
(24, NULL, 3, 'fff', '666666666', 'dfsa@fds', 'fdsa'),
(25, 7, 3, 'test', '123456789', 'test@test.cz', 'fdfd'),
(26, 7, 3, 'test', '123456789', 'test@test.cz', 'osos'),
(27, 7, 3, 'test', '123456789', 'test@test.cz', 'ososssss');

-- --------------------------------------------------------

--
-- Table structure for table `Images`
--

CREATE TABLE `Images` (
  `ID` int(11) NOT NULL,
  `IDOffer` int(11) NOT NULL,
  `Path` varchar(255) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Dumping data for table `Images`
--

INSERT INTO `Images` (`ID`, `IDOffer`, `Path`) VALUES
(1, 3, '/podklady\\new-mansion1.jfif'),
(2, 3, '/podklady\\mansion2.jfif'),
(5, 17, '\\podklady\\PXL_20230806_094430876.jpg'),
(6, 20, '\\podklady\\pngegg.png'),
(7, 21, '\\podklady\\scary2.png'),
(8, 22, '\\podklady\\home-img-07-370x250.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `Offers`
--

CREATE TABLE `Offers` (
  `ID` int(11) NOT NULL,
  `IDCategory` int(11) NOT NULL,
  `IDAdminSeller` int(11) NOT NULL,
  `Name` varchar(20) COLLATE utf8_czech_ci NOT NULL,
  `Price` int(11) NOT NULL,
  `ShortInfo` text COLLATE utf8_czech_ci NOT NULL,
  `Size` int(11) NOT NULL,
  `Region` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `Address` varchar(200) COLLATE utf8_czech_ci NOT NULL,
  `EnergeticClass` varchar(1) COLLATE utf8_czech_ci NOT NULL,
  `BigInfo` text COLLATE utf8_czech_ci NOT NULL,
  `Type` varchar(10) COLLATE utf8_czech_ci DEFAULT NULL,
  `Showed` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Dumping data for table `Offers`
--

INSERT INTO `Offers` (`ID`, `IDCategory`, `IDAdminSeller`, `Name`, `Price`, `ShortInfo`, `Size`, `Region`, `Address`, `EnergeticClass`, `BigInfo`, `Type`, `Showed`) VALUES
(1, 1, 2, 'Nejlepší byt', 10000, 'ossssssssssssssssss', 50, 'Praha 6', 'Květivnová 800', 'A', 'ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff', '2+1kk', 1),
(2, 4, 1, 'AVA Nob Hill', 11500, 'AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community. AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community.', 10, 'Čáslav', 'K Vodrantům', 'E', 'AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community. AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community.AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community. AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community.AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community. AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community.AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community. AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community.AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community. AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community.AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community. AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community.', '5+2kk', 1),
(3, 2, 1, 'Mansion', 50000, 'Amidst a sprawling landscape of manicured gardens and ancient oaks, a stately mansion rises, a timeless testament to opulence and grandeur. The imposing structure, adorned with intricate detailing and classical architecture, stands as a symbol of sophistication.', 400, 'Usa', 'Here', 'Z', 'Surrounded by meticulously landscaped gardens, the mansion is a haven of tranquility. Statuesque fountains and blooming flower beds accentuate the beauty of the estate. A meandering cobblestone path leads to a grand entrance, where the air is filled with the gentle fragrance of blossoms.\r\n\r\nAs evening descends, the mansion is bathed in the warm glow of strategically placed lights, casting a captivating radiance. The ambiance is one of elegance and grace, a scene straight from a bygone era.\r\n\r\nThis stately mansion is more than a dwelling; it is a statement of timeless elegance and refined living. A place where history and modernity seamlessly coexist, inviting those who enter to experience a life of unparalleled luxury.', '20+8kk', 1),
(4, 1, 1, 'Exkluzivní 3+1', 8900000, 'Moderní byt s impozantním výhledem na Vltavu a centrum Prahy.', 110, 'Praha 2, Vinohrady', 'Rumunska 5', 'A', 'Tento luxusní apartmán nabízí prostorný obývací pokoj, plně vybavenou kuchyň, a koupelnu se saunou. Ideální pro ty, kteří hledají pohodlí a elegance ve srdci města.', '3+1kk', 1),
(5, 3, 1, 'Rodinný dům ', 6200000, 'Útulný rodinný dům s prostornou zahradou a terasou.Velikost: 160 m²', 160, 'Brno, Žabovřesky', 'Václavské náměstí', 'B', 'Tento dům má tři ložnice, moderní kuchyň a obývací pokoj s výhledem do zahrady. Ideální pro rodiny, které hledají klidné a přátelské prostředí.', '1+1kk', 1),
(14, 4, 2, 'Funguj', 80000, 'fsadfasdf', 8000, 'Chomutov', 'U silnice 255', 'A', 'fasdfsd', '2+1kk', 1),
(15, 1, 2, 'Funguj pls', 564, 'fsadfasdf', 8000, 'Chomutov', 'U silnice 255', 'A', 'fsadf', '2+1kk', 1),
(17, 1, 1, 'fff', 5454, 'fsda', 10000000, 'Čáslav', 'K vodrantům ', 'A', 'fds', 'fasd', 0),
(20, 1, 1, 'testimg', 50000, 'ososososos', 50, 'Chomutov', 'U silnice 255', 'A', 'Jak to jdeee', 'pozemek', 1),
(21, 2, 2, 'testtest', 100000, 'To pujde', 10, 'Čáslav', 'U nás doma', 'A', 'Nejlepší dům, doma je doma', 'Dobrý', 1),
(22, 1, 1, 'fsadf', 200, 'fsdafa', 10, 'Čáslav', 'K vodrantům ', 'A', 'fsadfasdf', '1+kk', 0);

-- --------------------------------------------------------

--
-- Table structure for table `Users`
--

CREATE TABLE `Users` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `Email` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `Tel` varchar(15) COLLATE utf8_czech_ci NOT NULL,
  `LoginName` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `Password` text COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Dumping data for table `Users`
--

INSERT INTO `Users` (`ID`, `Name`, `Email`, `Tel`, `LoginName`, `Password`) VALUES
(1, 'Oliverrr', 'klfsjdakls@sdklfj.cz', '604585789', 'os', 'bdf306c6fa652a514fa3aafc78da3885780d37605b93088d5167eb99750158b7'),
(3, 'peterrrr', 'peter@d.cz', '123456789', 'p', '148de9c5a7a44d19e56cd9ae1a554bf67847afb0c58f6e12fa29ac7ddfca9940'),
(7, 'test', 'test@test.cz', '123456789', 'test', '9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08'),
(8, 'test2', 'test2@test.cz', '0000000000', 'test2', '60303ae22b998861bce3b28f33eec1be758a213c86c93c076dbe9f558c11c752');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `AdminSellers`
--
ALTER TABLE `AdminSellers`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `Attributes`
--
ALTER TABLE `Attributes`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `AttributesValues`
--
ALTER TABLE `AttributesValues`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `AttributValue` (`IDAttribute`),
  ADD KEY `AttributOffer` (`IDOffer`);

--
-- Indexes for table `Categories`
--
ALTER TABLE `Categories`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `Demands`
--
ALTER TABLE `Demands`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `UserDemands` (`IDUser`),
  ADD KEY `OfferDemands` (`IDOffer`);

--
-- Indexes for table `Images`
--
ALTER TABLE `Images`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ImageOffer` (`IDOffer`);

--
-- Indexes for table `Offers`
--
ALTER TABLE `Offers`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `AdminSellerOffers` (`IDAdminSeller`),
  ADD KEY `CategoriesOffers` (`IDCategory`);

--
-- Indexes for table `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `AdminSellers`
--
ALTER TABLE `AdminSellers`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `Attributes`
--
ALTER TABLE `Attributes`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `AttributesValues`
--
ALTER TABLE `AttributesValues`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT for table `Categories`
--
ALTER TABLE `Categories`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `Demands`
--
ALTER TABLE `Demands`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT for table `Images`
--
ALTER TABLE `Images`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `Offers`
--
ALTER TABLE `Offers`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `Users`
--
ALTER TABLE `Users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `AttributesValues`
--
ALTER TABLE `AttributesValues`
  ADD CONSTRAINT `AttributOffer` FOREIGN KEY (`IDOffer`) REFERENCES `Offers` (`ID`),
  ADD CONSTRAINT `AttributValue` FOREIGN KEY (`IDAttribute`) REFERENCES `Attributes` (`ID`);

--
-- Constraints for table `Demands`
--
ALTER TABLE `Demands`
  ADD CONSTRAINT `OfferDemands` FOREIGN KEY (`IDOffer`) REFERENCES `Offers` (`ID`),
  ADD CONSTRAINT `UserDemands` FOREIGN KEY (`IDUser`) REFERENCES `Users` (`ID`);

--
-- Constraints for table `Images`
--
ALTER TABLE `Images`
  ADD CONSTRAINT `ImageOffer` FOREIGN KEY (`IDOffer`) REFERENCES `Offers` (`ID`);

--
-- Constraints for table `Offers`
--
ALTER TABLE `Offers`
  ADD CONSTRAINT `AdminSellerOffers` FOREIGN KEY (`IDAdminSeller`) REFERENCES `AdminSellers` (`ID`),
  ADD CONSTRAINT `CategoriesOffers` FOREIGN KEY (`IDCategory`) REFERENCES `Categories` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
