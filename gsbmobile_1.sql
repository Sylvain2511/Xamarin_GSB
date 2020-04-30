-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Mar 30, 2020 at 01:14 PM
-- Server version: 10.4.10-MariaDB
-- PHP Version: 7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gsbmobile`
--

-- --------------------------------------------------------

--
-- Table structure for table `antibio`
--

DROP TABLE IF EXISTS `antibio`;
CREATE TABLE IF NOT EXISTS `antibio` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `libelle` varchar(100) NOT NULL,
  `unite` varchar(100) NOT NULL,
  `nombre_par_jour` int(11) NOT NULL,
  `doseKilo` int(11) DEFAULT NULL,
  `dosePrise` int(11) DEFAULT NULL,
  `type` enum('p','k') NOT NULL,
  `categorie_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `categorie_id` (`categorie_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `antibio`
--

INSERT INTO `antibio` (`id`, `libelle`, `unite`, `nombre_par_jour`, `doseKilo`, `dosePrise`, `type`, `categorie_id`) VALUES
(1, 'JuifOFour', 'mg', 3, 10, NULL, 'k', 2),
(2, 'PasDamalGam', 'mg', 20, NULL, 3, 'p', 1),
(3, 'Spasfon', 'mg', 1, 10, NULL, 'k', 4),
(4, 'Smecta', 'mg', 3, NULL, 4, 'p', 5),
(5, 'random', 'mg', 2, NULL, 3, 'p', 2);

-- --------------------------------------------------------

--
-- Table structure for table `categorie`
--

DROP TABLE IF EXISTS `categorie`;
CREATE TABLE IF NOT EXISTS `categorie` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `libelle` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `categorie`
--

INSERT INTO `categorie` (`id`, `libelle`) VALUES
(1, 'Aminoglycosides'),
(2, 'AntiFongiques'),
(3, 'Carbapénèmes'),
(4, 'Céphalosporines'),
(5, 'Macrolides'),
(6, 'Pénicillines'),
(7, 'Quinolones'),
(8, 'Sulfamidés'),
(9, 'Autres');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `antibio`
--
ALTER TABLE `antibio`
  ADD CONSTRAINT `antibio_ibfk_1` FOREIGN KEY (`categorie_id`) REFERENCES `categorie` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
