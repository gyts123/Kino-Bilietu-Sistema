-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 23, 2020 at 04:11 PM
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
  `kaina` decimal(10,0) DEFAULT NULL,
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
('Šrekas 4', 250, 'Eddie murphy', 'quentin tarantino', 'Amazing', 'https://www.youtube.com/watch?v=oHg5SJYRHA0', 4, 2);

-- --------------------------------------------------------

--
-- Table structure for table `kino_sale`
--

CREATE TABLE `kino_sale` (
  `pavadinimas` varchar(255) DEFAULT NULL,
  `id_Kino_sale` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
  `fk_Kino_saleid_Kino_sale` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
  `ar_uzsakyta` tinyint(1) DEFAULT 0,
  `vietos_tipas` int(11) DEFAULT NULL,
  `id_Vieta` int(11) NOT NULL,
  `fk_Kino_saleid_Kino_sale` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
  ADD KEY `priklauso` (`fk_Filmasid_Filmas`);

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
  MODIFY `id_Filmas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `kino_sale`
--
ALTER TABLE `kino_sale`
  MODIFY `id_Kino_sale` int(11) NOT NULL AUTO_INCREMENT;

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
  MODIFY `id_Rodymo_laikas` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `saskaita`
--
ALTER TABLE `saskaita`
  MODIFY `id_Saskaita` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `vieta`
--
ALTER TABLE `vieta`
  MODIFY `id_Vieta` int(11) NOT NULL AUTO_INCREMENT;

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
  ADD CONSTRAINT `priklauso` FOREIGN KEY (`fk_Filmasid_Filmas`) REFERENCES `filmas` (`id_Filmas`);

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
