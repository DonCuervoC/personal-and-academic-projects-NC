-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 15-11-2022 a las 19:24:41
-- Versión del servidor: 8.0.27
-- Versión de PHP: 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `projetpanier`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `panier`
--

DROP TABLE IF EXISTS `panier`;
CREATE TABLE IF NOT EXISTS `panier` (
  `id_panier` int NOT NULL AUTO_INCREMENT,
  `Date_modification` date NOT NULL,
  `id_produit1` int DEFAULT NULL,
  `quantite_p1` int DEFAULT NULL,
  `prix1` int DEFAULT NULL,
  `id_produit2` int DEFAULT NULL,
  `quantite_p2` int DEFAULT NULL,
  `prix2` int DEFAULT NULL,
  `id_produit3` int DEFAULT NULL,
  `quantite_p3` int DEFAULT NULL,
  `prix3` int DEFAULT NULL,
  `id_produit4` int DEFAULT NULL,
  `quantite_p4` int DEFAULT NULL,
  `prix` int DEFAULT NULL,
  `id_produit5` int DEFAULT NULL,
  `quantite_p5` int DEFAULT NULL,
  `prix5` int DEFAULT NULL,
  `prixTotal` int NOT NULL,
  PRIMARY KEY (`id_panier`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `panierachat`
--

DROP TABLE IF EXISTS `panierachat`;
CREATE TABLE IF NOT EXISTS `panierachat` (
  `id_panier` int NOT NULL AUTO_INCREMENT,
  `Date_modification` date NOT NULL,
  `id_prod` int NOT NULL,
  `nom_produit` int NOT NULL,
  `quantite_p` int NOT NULL,
  `quantite_Selectione` int NOT NULL,
  `prix` int NOT NULL,
  `prixTotal` int NOT NULL,
  PRIMARY KEY (`id_panier`)
) ENGINE=MyISAM AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `panierachat`
--

INSERT INTO `panierachat` (`id_panier`, `Date_modification`, `id_prod`, `nom_produit`, `quantite_p`, `quantite_Selectione`, `prix`, `prixTotal`) VALUES
(17, '2022-11-14', 1, 0, 100, 2, 400, 800),
(18, '2022-11-15', 1, 0, 101, 1, 400, 400),
(19, '2022-11-15', 1, 0, 101, 2, 400, 800);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `produits`
--

DROP TABLE IF EXISTS `produits`;
CREATE TABLE IF NOT EXISTS `produits` (
  `id_produit` int NOT NULL AUTO_INCREMENT,
  `nom_produit` varchar(20) NOT NULL,
  `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `quantite_disponible` int NOT NULL,
  `image` varchar(100) NOT NULL,
  `date_creation` datetime NOT NULL,
  `prix` int NOT NULL,
  PRIMARY KEY (`id_produit`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `produits`
--

INSERT INTO `produits` (`id_produit`, `nom_produit`, `description`, `quantite_disponible`, `image`, `date_creation`, `prix`) VALUES
(1, 'Bonsaï', 'Le bonsaï (盆栽, bonsai?) ou bonzaï1, culture miniaturisée de végétaux en pot, est un art traditionnel chinois également art majeur au Japon. Il est originaire de Chine où il a d\'abord été développé sous une forme plus complexe appelée penjing, représentant un mini paysage en pot, puis simplfiée en penzai (prononcé bonzai au Japon), avant que cet art ne soit ammené quelques siècles plus tard au Japon. Cette pratique se retrouve également dans les cultures d\'autres pays de cette région du monde comme le Vietnam ou la Corée sous l\'influence chinoise.\r\nLa plante ou l\'arbre qui en est l\'objet est miniaturisé par application de différentes techniques (taille des branches et racines, gestion des apports nutritifs...) et modelage de la forme (par ligature). Le but en est une recherche esthétique et la ressemblance de l\'arbre avec la nature.', 101, 'bonsai.jpg', '2022-11-07 19:34:09', 400),
(2, 'Le dracaena', 'Les Dracaena appartiennent à la famille des asperges et ressemblent à de petits arbres ou à de succulents arbustes. Aujourd\'hui, selon diverses sources, jusqu\'à 150 espèces sont connues. Malgré le fait qu\'en milieu naturel, une grande partie d\'entre eux pousse en Afrique, comme plante d\'intérieur, la dracaena peut être trouvée presque partout dans le monde. L\'un des types les plus populaires est le dracaena parfumé, qui sera discuté dans notre article.', 50, 'dracanea.jpg', '2022-11-07 19:34:09', 100),
(3, 'le pilea porte-bonhe', 'Le dracéna fait partie de la famille des agavacées (Agavaceae). Ce sont des plantes vertes originaires de climats chauds et humides tels que l’Asie, l’Amérique centrale et certaines régions tropicales de l’Afrique.\r\nLes dragonniers se caractérisent par leurs longues feuilles vertes, parfois striées de rayures rouges, brunes, blanches ou jaunes, qui poussent aux extrémités de tiges dont la base se dégarnit avec les années, ce qui leur donnent des airs de petits palmiers.\r\nLes dracaena sont aussi considérés comme des plantes dépolluantes, absorbant les polluants contenus dans l’air et dégageant plus d’oxygène qu’ils n’en consomment. ', 50, 'pilea.jpg', '2022-11-07 19:58:12', 25),
(4, 'le cyclamen', 'Le cyclamen appartient à la même famille que les primevères (primulacées) et est originaire du Moyen-Orient. Les cyclamens atteignent généralement 15 cm de hauteur et offrent des fleurs blanches, mauves, roses ou rouges. Le cyclamen persicum, également appelé cyclamen des fleuristes, a donné naissance à la plupart des espèces hybrides. Le feuillage du cyclamen est tout aussi intéressant que la fleur avec sa couleur vert foncé marbré et ses taches de vert plus clair.', 100, 'cyclamen.jpg', '2022-11-07 19:58:12', 35),
(5, 'Cactus', '(Botanique) Genre de plantes grasses dont la tige est en général charnue, garnie d\'aiguillons en faisceaux et ordinairement dépourvue de feuilles. Ce sont des plantes dites xérophytes qui stockent dans leurs tissus des réserves de suc pour faire face aux longues périodes de sécheresse.', 100, 'cactus.jpg', '2022-11-07 20:06:01', 75);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
