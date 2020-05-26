-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 26, 2020 at 09:32 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.2.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `er_modelis`
--

-- --------------------------------------------------------

--
-- Table structure for table `atsiliepimas`
--

CREATE TABLE `atsiliepimas` (
  `aprasymas` varchar(255) DEFAULT NULL,
  `rating` int(11) DEFAULT NULL,
  `id_Atsiliepimas` int(11) NOT NULL,
  `fk_Naudotojasid_Naudotojas` int(11) NOT NULL,
  `fk_Filmasid_Filmas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `bilietas`
--

CREATE TABLE `bilietas` (
  `ar_panaudotas` tinyint(1) DEFAULT 0,
  `amziaus_cenzas` int(11) DEFAULT NULL,
  `ar_užrezervuotas` tinyint(1) DEFAULT 0,
  `id_Bilietas` int(11) NOT NULL,
  `fk_Rodymo_laikasid_Rodymo_laikas` int(11) NOT NULL,
  `fk_Vietaid_Vieta` int(11) NOT NULL,
  `fk_Saskaitaid_Saskaita` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `busena`
--

CREATE TABLE `busena` (
  `id_Busena` int(11) NOT NULL,
  `name` char(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `busena`
--

INSERT INTO `busena` (`id_Busena`, `name`) VALUES
(1, 'uzblokuotas'),
(2, 'aktyvus');

-- --------------------------------------------------------

--
-- Table structure for table `filmas`
--

CREATE TABLE `filmas` (
  `pavadinimas` varchar(255) DEFAULT NULL,
  `trukme` int(11) DEFAULT NULL,
  `aktoriai` varchar(255) DEFAULT NULL,
  `rezisierius` varchar(255) DEFAULT NULL,
  `aprasymas` varchar(255) DEFAULT NULL,
  `anonsas` varchar(255) DEFAULT NULL,
  `zanras` int(11) DEFAULT NULL,
  `id_Filmas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `filmas`
--

INSERT INTO `filmas` (`pavadinimas`, `trukme`, `aktoriai`, `rezisierius`, `aprasymas`, `anonsas`, `zanras`, `id_Filmas`) VALUES
('mahmood', 4, 'adsfsad', 'joad', 'wqr', 'rqewr', 2, 1),
('Šrekas 4', 250, 'Eddie murphy', 'quentin tarantino', 'Amazing', 'https://www.youtube.com/watch?v=oHg5SJYRHA0', 4, 2),
('afsdfdasdf', 6, 'efawdsfs, shfdgfds', 'adfasdfasd', 'adsfsda', '312', 5, 3),
('qewrqewr', 5646, 'poiuystesardr', 'yui', 'adsfsgkf', 'uyrut', 12, 4),
('a', 0, 'a', 'a', 'a', 'a', 7, 5);

-- --------------------------------------------------------

--
-- Table structure for table `filmopradlaikai`
--

CREATE TABLE `filmopradlaikai` (
  `id_FilmoPradLaikai` int(11) NOT NULL,
  `name` char(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `filmopradlaikai`
--

INSERT INTO `filmopradlaikai` (`id_FilmoPradLaikai`, `name`) VALUES
(1, '09:00'),
(2, '12:00'),
(3, '15:00'),
(4, '18:00'),
(5, '21:00');

-- --------------------------------------------------------

--
-- Table structure for table `kino_sale`
--

CREATE TABLE `kino_sale` (
  `pavadinimas` varchar(255) DEFAULT NULL,
  `id_Kino_sale` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `kino_sale`
--

INSERT INTO `kino_sale` (`pavadinimas`, `id_Kino_sale`) VALUES
('Pirma Salė', 34),
('Antra Salė', 35),
('Trečia salė', 36),
(NULL, 37),
('Hehe', 38),
('Hehe', 39),
('Bobik', 40),
('Saliki', 41),
('lol', 42),
('lol', 43),
('lol', 44),
('llll', 45),
('baravyk', 46),
(NULL, 47);

-- --------------------------------------------------------

--
-- Table structure for table `komentaras`
--

CREATE TABLE `komentaras` (
  `komentaras` varchar(255) DEFAULT NULL,
  `data` date DEFAULT NULL,
  `id_Komentaras` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `naudotojas`
--

CREATE TABLE `naudotojas` (
  `elpastas` varchar(255) DEFAULT NULL,
  `slaptazodis` varchar(255) DEFAULT NULL,
  `naudotojo_vardas` varchar(255) DEFAULT NULL,
  `telnr` varchar(255) DEFAULT NULL,
  `id_Naudotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `pranešimai`
--

CREATE TABLE `pranešimai` (
  `pranesimas` varchar(255) DEFAULT NULL,
  `data` date DEFAULT NULL,
  `id_Pranešimai` int(11) NOT NULL,
  `fk_Naudotojasid_Naudotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `rodymo_laikas`
--

CREATE TABLE `rodymo_laikas` (
  `laikas` date DEFAULT NULL,
  `id_Rodymo_laikas` int(11) NOT NULL,
  `fk_Filmasid_Filmas` int(11) NOT NULL,
  `fk_Kino_saleid_Kino_sale` int(11) NOT NULL,
  `filmo_prad_laik` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `rodymo_laikas`
--

INSERT INTO `rodymo_laikas` (`laikas`, `id_Rodymo_laikas`, `fk_Filmasid_Filmas`, `fk_Kino_saleid_Kino_sale`, `filmo_prad_laik`) VALUES
('2020-05-23', 1, 2, 34, 2),
('2020-05-24', 2, 3, 34, 3);

-- --------------------------------------------------------

--
-- Table structure for table `saskaita`
--

CREATE TABLE `saskaita` (
  `pavedimoNr` varchar(255) DEFAULT NULL,
  `visa_kaina` decimal(10,0) DEFAULT NULL,
  `id_Saskaita` int(11) NOT NULL,
  `fk_Naudotojasid_Naudotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `vieta`
--

CREATE TABLE `vieta` (
  `eiles_nr` int(11) DEFAULT NULL,
  `vietos_nr` int(11) DEFAULT NULL,
  `kaina` float NOT NULL,
  `ar_uzsakyta` tinyint(1) DEFAULT 0,
  `vietos_tipas` int(11) DEFAULT NULL,
  `id_Vieta` int(11) NOT NULL,
  `fk_Kino_saleid_Kino_sale` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `vieta`
--

INSERT INTO `vieta` (`eiles_nr`, `vietos_nr`, `kaina`, `ar_uzsakyta`, `vietos_tipas`, `id_Vieta`, `fk_Kino_saleid_Kino_sale`) VALUES
(0, 0, 0, 0, 2, 6, 34),
(0, 1, 0, 0, 1, 7, 34),
(0, 2, 0, 0, 3, 8, 34),
(0, 3, 0, 0, 1, 9, 34),
(0, 4, 0, 0, 1, 10, 34),
(1, 0, 0, 0, 1, 11, 34),
(1, 1, 0, 0, 2, 12, 34),
(1, 2, 0, 0, 1, 13, 34),
(1, 3, 0, 0, 1, 14, 34),
(1, 4, 0, 0, 1, 15, 34),
(0, 0, 0, 0, 1, 16, 35),
(0, 1, 0, 0, 1, 17, 35),
(0, 2, 0, 0, 1, 18, 35),
(1, 0, 0, 0, 1, 19, 35),
(1, 1, 0, 0, 1, 20, 35),
(1, 2, 0, 0, 1, 21, 35),
(2, 0, 0, 0, 3, 22, 35),
(2, 1, 0, 0, 3, 23, 35),
(2, 2, 0, 0, 3, 24, 35),
(0, 0, 0, 0, 3, 25, 36),
(0, 1, 0, 0, 1, 26, 36),
(0, 2, 0, 0, 1, 27, 36),
(0, 3, 0, 0, 1, 28, 36),
(0, 4, 0, 0, 1, 29, 36),
(1, 0, 0, 0, 1, 30, 36),
(1, 1, 0, 0, 1, 31, 36),
(1, 2, 0, 0, 1, 32, 36),
(1, 3, 0, 0, 1, 33, 36),
(1, 4, 0, 0, 1, 34, 36),
(2, 0, 0, 0, 1, 35, 36),
(2, 1, 0, 0, 1, 36, 36),
(2, 2, 0, 0, 2, 37, 36),
(2, 3, 0, 0, 1, 38, 36),
(2, 4, 0, 0, 1, 39, 36),
(3, 0, 0, 0, 1, 40, 36),
(3, 1, 0, 0, 1, 41, 36),
(3, 2, 0, 0, 2, 42, 36),
(3, 3, 0, 0, 1, 43, 36),
(3, 4, 0, 0, 1, 44, 36),
(4, 0, 0, 0, 1, 45, 36),
(4, 1, 0, 0, 1, 46, 36),
(4, 2, 0, 0, 1, 47, 36),
(4, 3, 0, 0, 1, 48, 36),
(4, 4, 0, 0, 1, 49, 36),
(0, 0, 1, 0, 1, 58, 46),
(0, 1, 2, 0, 1, 59, 46),
(1, 0, 3, 0, 1, 60, 46),
(1, 1, 4, 0, 1, 61, 46),
(0, 0, 0, 0, 1, 62, 47),
(0, 1, 0, 0, 1, 63, 47),
(0, 2, 0, 0, 1, 64, 47),
(0, 3, 3, 0, 1, 65, 47),
(1, 0, 2, 0, 1, 66, 47),
(1, 1, 2, 0, 1, 67, 47),
(1, 2, 2, 0, 1, 68, 47),
(1, 3, 2, 0, 1, 69, 47),
(2, 0, 2, 0, 1, 70, 47),
(2, 1, 2, 0, 1, 71, 47),
(2, 2, 2, 0, 1, 72, 47),
(2, 3, 2, 0, 1, 73, 47),
(3, 0, 2, 0, 1, 74, 47),
(3, 1, 2, 0, 1, 75, 47),
(3, 2, 2, 0, 3, 76, 47),
(3, 3, 2, 0, 1, 77, 47);

-- --------------------------------------------------------

--
-- Table structure for table `vietu_tipai`
--

CREATE TABLE `vietu_tipai` (
  `id_Vietu_tipai` int(11) NOT NULL,
  `name` char(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `vietu_tipai`
--

INSERT INTO `vietu_tipai` (`id_Vietu_tipai`, `name`) VALUES
(1, 'paprastas'),
(2, 'dvivietis'),
(3, 'V.I.P');

-- --------------------------------------------------------

--
-- Table structure for table `zanrai`
--

CREATE TABLE `zanrai` (
  `id_Zanrai` int(11) NOT NULL,
  `name` char(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `zanrai`
--

INSERT INTO `zanrai` (`id_Zanrai`, `name`) VALUES
(1, 'detektyvinis'),
(2, 'eksplotacinis'),
(3, 'istorinis'),
(4, 'animacinis'),
(5, 'karinis'),
(6, 'kriminialinis'),
(7, 'komedijinis'),
(8, 'mokslinis'),
(9, 'nuotykiu'),
(10, 'romantinis'),
(11, 'siaubo'),
(12, 'trileris'),
(13, 'veiksmo');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `atsiliepimas`
--
ALTER TABLE `atsiliepimas`
  ADD PRIMARY KEY (`id_Atsiliepimas`),
  ADD KEY `Palieka` (`fk_Naudotojasid_Naudotojas`),
  ADD KEY `gauna` (`fk_Filmasid_Filmas`);

--
-- Indexes for table `bilietas`
--
ALTER TABLE `bilietas`
  ADD PRIMARY KEY (`id_Bilietas`),
  ADD KEY `g` (`fk_Vietaid_Vieta`),
  ADD KEY `yra` (`fk_Rodymo_laikasid_Rodymo_laikas`),
  ADD KEY `ieina` (`fk_Saskaitaid_Saskaita`);

--
-- Indexes for table `busena`
--
ALTER TABLE `busena`
  ADD PRIMARY KEY (`id_Busena`);

--
-- Indexes for table `filmas`
--
ALTER TABLE `filmas`
  ADD PRIMARY KEY (`id_Filmas`),
  ADD KEY `zanras` (`zanras`);

--
-- Indexes for table `filmopradlaikai`
--
ALTER TABLE `filmopradlaikai`
  ADD PRIMARY KEY (`id_FilmoPradLaikai`);

--
-- Indexes for table `kino_sale`
--
ALTER TABLE `kino_sale`
  ADD PRIMARY KEY (`id_Kino_sale`);

--
-- Indexes for table `komentaras`
--
ALTER TABLE `komentaras`
  ADD PRIMARY KEY (`id_Komentaras`);

--
-- Indexes for table `naudotojas`
--
ALTER TABLE `naudotojas`
  ADD PRIMARY KEY (`id_Naudotojas`);

--
-- Indexes for table `pranešimai`
--
ALTER TABLE `pranešimai`
  ADD PRIMARY KEY (`id_Pranešimai`),
  ADD KEY `pateikti` (`fk_Naudotojasid_Naudotojas`);

--
-- Indexes for table `rodymo_laikas`
--
ALTER TABLE `rodymo_laikas`
  ADD PRIMARY KEY (`id_Rodymo_laikas`),
  ADD KEY `priklauso` (`fk_Filmasid_Filmas`),
  ADD KEY `filmo_prad_laik` (`filmo_prad_laik`);

--
-- Indexes for table `saskaita`
--
ALTER TABLE `saskaita`
  ADD PRIMARY KEY (`id_Saskaita`),
  ADD KEY `sudaro` (`fk_Naudotojasid_Naudotojas`);

--
-- Indexes for table `vieta`
--
ALTER TABLE `vieta`
  ADD PRIMARY KEY (`id_Vieta`),
  ADD KEY `vietos_tipas` (`vietos_tipas`),
  ADD KEY `turi` (`fk_Kino_saleid_Kino_sale`);

--
-- Indexes for table `vietu_tipai`
--
ALTER TABLE `vietu_tipai`
  ADD PRIMARY KEY (`id_Vietu_tipai`);

--
-- Indexes for table `zanrai`
--
ALTER TABLE `zanrai`
  ADD PRIMARY KEY (`id_Zanrai`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `atsiliepimas`
--
ALTER TABLE `atsiliepimas`
  MODIFY `id_Atsiliepimas` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `bilietas`
--
ALTER TABLE `bilietas`
  MODIFY `id_Bilietas` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `filmas`
--
ALTER TABLE `filmas`
  MODIFY `id_Filmas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `kino_sale`
--
ALTER TABLE `kino_sale`
  MODIFY `id_Kino_sale` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=48;

--
-- AUTO_INCREMENT for table `komentaras`
--
ALTER TABLE `komentaras`
  MODIFY `id_Komentaras` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `naudotojas`
--
ALTER TABLE `naudotojas`
  MODIFY `id_Naudotojas` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `pranešimai`
--
ALTER TABLE `pranešimai`
  MODIFY `id_Pranešimai` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `rodymo_laikas`
--
ALTER TABLE `rodymo_laikas`
  MODIFY `id_Rodymo_laikas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `saskaita`
--
ALTER TABLE `saskaita`
  MODIFY `id_Saskaita` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `vieta`
--
ALTER TABLE `vieta`
  MODIFY `id_Vieta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=78;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `atsiliepimas`
--
ALTER TABLE `atsiliepimas`
  ADD CONSTRAINT `Palieka` FOREIGN KEY (`fk_Naudotojasid_Naudotojas`) REFERENCES `naudotojas` (`id_Naudotojas`),
  ADD CONSTRAINT `gauna` FOREIGN KEY (`fk_Filmasid_Filmas`) REFERENCES `filmas` (`id_Filmas`);

--
-- Constraints for table `bilietas`
--
ALTER TABLE `bilietas`
  ADD CONSTRAINT `g` FOREIGN KEY (`fk_Vietaid_Vieta`) REFERENCES `vieta` (`id_Vieta`),
  ADD CONSTRAINT `ieina` FOREIGN KEY (`fk_Saskaitaid_Saskaita`) REFERENCES `saskaita` (`id_Saskaita`),
  ADD CONSTRAINT `yra` FOREIGN KEY (`fk_Rodymo_laikasid_Rodymo_laikas`) REFERENCES `rodymo_laikas` (`id_Rodymo_laikas`);

--
-- Constraints for table `filmas`
--
ALTER TABLE `filmas`
  ADD CONSTRAINT `filmas_ibfk_1` FOREIGN KEY (`zanras`) REFERENCES `zanrai` (`id_Zanrai`);

--
-- Constraints for table `pranešimai`
--
ALTER TABLE `pranešimai`
  ADD CONSTRAINT `pateikti` FOREIGN KEY (`fk_Naudotojasid_Naudotojas`) REFERENCES `naudotojas` (`id_Naudotojas`);

--
-- Constraints for table `rodymo_laikas`
--
ALTER TABLE `rodymo_laikas`
  ADD CONSTRAINT `priklauso` FOREIGN KEY (`fk_Filmasid_Filmas`) REFERENCES `filmas` (`id_Filmas`),
  ADD CONSTRAINT `rodymo_laikas_ibfk_1` FOREIGN KEY (`filmo_prad_laik`) REFERENCES `filmopradlaikai` (`id_FilmoPradLaikai`);

--
-- Constraints for table `saskaita`
--
ALTER TABLE `saskaita`
  ADD CONSTRAINT `sudaro` FOREIGN KEY (`fk_Naudotojasid_Naudotojas`) REFERENCES `naudotojas` (`id_Naudotojas`);

--
-- Constraints for table `vieta`
--
ALTER TABLE `vieta`
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_Kino_saleid_Kino_sale`) REFERENCES `kino_sale` (`id_Kino_sale`),
  ADD CONSTRAINT `vieta_ibfk_1` FOREIGN KEY (`vietos_tipas`) REFERENCES `vietu_tipai` (`id_Vietu_tipai`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
