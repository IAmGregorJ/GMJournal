-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: mysql21.unoeuro.com
-- Generation Time: Mar 21, 2020 at 07:21 AM
-- Server version: 5.7.29-32-log
-- PHP Version: 7.3.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `thisismycode_site_db_study`
--

-- --------------------------------------------------------

--
-- Table structure for table `people`
--

CREATE TABLE `people` (
  `id` int(4) NOT NULL,
  `type` enum('user','citizen') NOT NULL,
  `cpr` text NOT NULL,
  `name` text NOT NULL,
  `address` text NOT NULL,
  `maalgruppe` text,
  `position` enum('System Administrator','Sagsbehandler') DEFAULT NULL,
  `username` text,
  `password` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `people`
--

INSERT INTO `people` (`id`, `type`, `cpr`, `name`, `address`, `maalgruppe`, `position`, `username`, `password`) VALUES
(1, 'user', '0104909995', 'Sverre Mosebryggersen', 'Ole Worms Gade 4, 8700 Horsens', '', 'System Administrator', 'grema', 'grema'),
(2, 'user', '0201609996', 'Lonni Lauridsen', 'Gersdorffsgade 15, 8700 Horsens', '', 'Sagsbehandler', 'line', 'line'),
(3, 'citizen', '0104909989', 'Torre Mosebryggersen', 'Bjerregade 1, 7100 Vejle', '1.2.2.2 Depression', '', '', NULL),
(4, 'citizen', '0107729995', 'Max Berggren', 'Herredsvej 1, 7100 Vejle', '', '', '', NULL),
(5, 'citizen', '0108589995', 'Schwendlund Mosebryggersen', 'Jaltevej 1, 7100 Vejle', '', '', '', NULL),
(6, 'user', '0108629996', 'May Moberg', 'Nørregade 14, 8700 Horsens', '', 'Sagsbehandler', 'casper', 'casper'),
(7, 'user', '0201609995', 'Einer Lauridsen', 'Fjordvej 151, 9631 Gedsted', '', 'Sagsbehandler', 'lis', 'lis'),
(9, 'user', '0201919990', 'Else Lauridsen', 'Kirketerpvej 17, 9541 Suldrup', '', 'Sagsbehandler', 'poul', 'poul'),
(10, 'citizen', '0211223989', 'Åge Berggren', 'Søndergade 4, 7100 Vejle', '2.10 Selvskadende adfærd', '', '', ''),
(13, 'user', '0201919996', 'Ellen Lauridsen', 'Langelinie 12, 8700 Horsens', '', 'Sagsbehandler', 'mette', 'mette'),
(14, 'citizen', '0212159995', 'Bo Vestergaard', 'Havneparken 77, 7100 Vejle', '2.6 Omsorgssvigt', NULL, NULL, NULL),
(15, 'citizen', '1110109996', 'Juliane Jørgensen', 'Buen 12, 7100 Vejle ', '', NULL, NULL, NULL),
(16, 'citizen', '1502779995', 'Ruddi Berggren', 'Adressevej 57, 8000 Århus C.', '', NULL, NULL, NULL),
(17, 'citizen', '2103009996', 'Kaja Hansen', 'Parkvej 7, 8600 Silkeborg', '', NULL, NULL, NULL),
(18, 'user', '2311143995', 'Cæcar Østergaard', 'Tæppevænget 42, 8900 Randers', NULL, 'Sagsbehandler', 'jens', 'jens'),
(19, 'citizen', '2509479989', 'Bruno Elmer', 'Fjordvej 78, 8000 Århus C', '1.2.1.4 Udviklingshæmning', NULL, NULL, NULL),
(20, 'user', '2512489996', 'Nancy Ann Berggren', 'Mølleparken 434, 7000 Fredericia', NULL, 'Sagsbehandler', 'ina', 'ina'),
(21, 'citizen', '3001749995', 'Niels Vendelboe', 'Tomatvænget 15, 7100 Vejle', '2.12 Social isolation', NULL, NULL, NULL),
(35, 'citizen', '0201919995', 'EK Lauridsen', 'Testgrusgraven 3, 8700 Horsens', '1.2.1.4 Udviklingshæmning', NULL, NULL, NULL),
(36, 'citizen', '0504909989', 'Rasmus Lauridsen', 'Minthøjvej 15, 8220 Aarhus V.', '2.8 Prostitution', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `udredning`
--

CREATE TABLE `udredning` (
  `id` int(4) NOT NULL,
  `date` date NOT NULL,
  `cpr` text NOT NULL,
  `fysiskFunktionsnedsaettelse` mediumtext NOT NULL,
  `psykiskFunktionsnedsaettelse` mediumtext NOT NULL,
  `socialtProblem` mediumtext NOT NULL,
  `praktiskeOpgaverIHjemmet` mediumtext NOT NULL,
  `egenomsorg` mediumtext NOT NULL,
  `mobilitet` mediumtext NOT NULL,
  `kommunikation` mediumtext NOT NULL,
  `samfundsliv` mediumtext NOT NULL,
  `socialtLiv` mediumtext NOT NULL,
  `sundhed` mediumtext NOT NULL,
  `omgivelser` mediumtext NOT NULL,
  `samletFagligVurdering` mediumtext NOT NULL,
  `samletFagligVurderingBeskrivelse` mediumtext NOT NULL,
  `maalgruppe` mediumtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `udredning`
--

INSERT INTO `udredning` (`id`, `date`, `cpr`, `fysiskFunktionsnedsaettelse`, `psykiskFunktionsnedsaettelse`, `socialtProblem`, `praktiskeOpgaverIHjemmet`, `egenomsorg`, `mobilitet`, `kommunikation`, `samfundsliv`, `socialtLiv`, `sundhed`, `omgivelser`, `samletFagligVurdering`, `samletFagligVurderingBeskrivelse`, `maalgruppe`) VALUES
(9, '2019-12-06', '2509479989', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam consequat leo in metus suscipit, at accumsan nisl luctus. Donec egestas dui neque, at accumsan ex scelerisque eu. Integer maximus ligula et elit luctus sodales. Curabitur laoreet felis id tellus aliquet pretium eu a erat. Sed at maximus quam, sit amet dignissim odio. Nullam mattis dignissim metus et ultricies. Curabitur at urna lacus. Maecenas eleifend suscipit massa at elementum. Nulla elementum sed nulla sed aliquam. Integer aliquet congue nisi at finibus. Sed facilisis elementum risus, eu venenatis ligula. Aliquam tristique odio justo, in faucibus augue finibus sit amet. Donec iaculis non augue at accumsan. Nullam sodales, orci vitae faucibus venenatis, magna turpis bibendum dui, vitae vulputate velit ipsum vitae sem. ', 'Praesent non rhoncus mi. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec quis tincidunt libero. Etiam pulvinar eget dui vel hendrerit. Nam tristique luctus maximus. Cras faucibus, erat eget commodo volutpat, urna sapien maximus ante, vel eleifend ante augue vel augue. Phasellus ac lacus velit. Aliquam dictum, ipsum sed gravida varius, sem ipsum elementum est, non venenatis ante turpis aliquam diam. Aliquam interdum fringilla lorem, id aliquam mauris sollicitudin nec. ', 'Vestibulum nec varius ipsum, vehicula ultrices mi. In mattis dui quam, eu venenatis massa rhoncus non. Sed scelerisque turpis ut tristique tristique. Vivamus lacinia purus mauris, in sodales lorem imperdiet ac. Mauris sit amet lacinia mauris. Curabitur at rhoncus quam, eu ultricies tortor. Nullam in ligula ac erat faucibus bibendum in quis dolor. Curabitur ac velit non purus posuere finibus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Praesent eu tincidunt sem. ', 'Nullam et sagittis nunc. Proin facilisis velit lectus, eu dictum justo bibendum in. Proin risus urna, varius vitae nibh id, fringilla suscipit quam. Morbi tincidunt elit in ligula aliquam, non lobortis massa aliquam. Sed at dui lectus. Proin faucibus neque tempor elit interdum blandit. Sed ac ex enim. Vestibulum molestie, metus sit amet aliquam pharetra, ante risus molestie tellus, ut ornare nunc nisl interdum erat. Curabitur luctus massa non leo eleifend auctor. Nullam accumsan nunc mauris, in congue lorem consequat vitae. Curabitur sed pellentesque felis. Interdum et malesuada fames ac ante ipsum primis in faucibus. Sed vitae mi vel felis dignissim tempus. Vestibulum eleifend mollis lorem, ac congue justo tincidunt ac. Phasellus et diam at urna pharetra auctor vel nec urna. ', 'Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aenean imperdiet lorem sit amet diam bibendum, ac lobortis dolor ultricies. In vitae congue diam, eget feugiat mi. Nam mattis vulputate lacinia. Phasellus elementum maximus quam, sit amet efficitur purus ullamcorper vitae. Nunc ut imperdiet mauris, nec feugiat erat. Phasellus in auctor tellus. Donec sit amet luctus velit, vitae commodo massa. ', 'Proin eget efficitur sapien. Proin mollis urna magna, a tincidunt urna congue ac. Proin a convallis justo. Mauris cursus ultricies nulla, in sodales ex sollicitudin vitae. Maecenas commodo est sed pretium molestie. Sed suscipit massa eu velit dictum molestie. Praesent placerat posuere purus, id pretium erat ullamcorper sed. ', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ac dui eget justo tempor porttitor. Maecenas in efficitur urna. Maecenas non lobortis purus. Morbi maximus mattis eros, ac finibus tortor pharetra nec. Aenean et ipsum nec velit molestie malesuada at vitae nisl. In vehicula, orci quis bibendum scelerisque, ex augue aliquam tortor, in gravida felis nisi vel risus. Integer id erat pellentesque, rutrum ante sit amet, vehicula neque. Cras tincidunt elit ac odio rhoncus, at hendrerit augue facilisis. Phasellus in venenatis erat, in molestie lectus. ', 'Quisque viverra lorem at congue accumsan. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Sed pulvinar nibh metus, nec maximus massa euismod commodo. Donec facilisis arcu sed velit ornare efficitur. Nam sem ipsum, consectetur sed neque eu, tempor ornare leo. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla in rhoncus diam, vel efficitur arcu. Nulla vitae velit sed augue blandit aliquet ut at orci. ', 'Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aenean consectetur porta massa non molestie. Sed vestibulum convallis est, vel varius mauris sollicitudin id. Quisque nibh nulla, aliquam condimentum commodo ut, condimentum nec ligula. Donec et mattis orci. Sed faucibus nibh ullamcorper orci interdum, id aliquam ante tempor. Duis accumsan libero magna, ac ultricies mi iaculis eu. Nam ut gravida nibh. Aenean dignissim metus ante, a porta orci tempus nec. Nam malesuada enim quis orci tristique, id accumsan purus egestas. ', 'Proin eget efficitur sapien. Proin mollis urna magna, a tincidunt urna congue ac. Proin a convallis justo. Mauris cursus ultricies nulla, in sodales ex sollicitudin vitae. Maecenas commodo est sed pretium molestie. Sed suscipit massa eu velit dictum molestie. Praesent placerat posuere purus, id pretium erat ullamcorper sed. ', 'Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aenean imperdiet lorem sit amet diam bibendum, ac lobortis dolor ultricies. In vitae congue diam, eget feugiat mi. Nam mattis vulputate lacinia. Phasellus elementum maximus quam, sit amet efficitur purus ullamcorper vitae. Nunc ut imperdiet mauris, nec feugiat erat. Phasellus in auctor tellus. Donec sit amet luctus velit, vitae commodo massa. ', 'D - Svært problem (omfattende, meget)', 'Nullam in congue leo. Vivamus tempus, elit a aliquam semper, ipsum arcu sollicitudin sapien, ac sagittis ligula urna eget felis. Duis ac sem placerat, bibendum lacus ut, mollis est. Phasellus convallis tellus eget nulla molestie sagittis. Curabitur ut neque accumsan metus vestibulum fermentum id non nulla. Cras efficitur, tortor et elementum lobortis, est erat pretium diam, vitae eleifend diam leo sit amet augue. In faucibus pulvinar mi ultrices tincidunt. Aliquam fermentum odio id quam finibus pharetra. Aenean hendrerit leo sed fringilla luctus. Fusce maximus rhoncus ultrices. Morbi efficitur pharetra erat. Vestibulum porta, libero at pulvinar tempor, lorem lacus volutpat augue, a efficitur dolor odio id neque. Integer pretium pharetra risus id ultricies. Aenean pulvinar euismod libero et dapibus. Cras volutpat dignissim lacus, nec maximus mi aliquam ut. Morbi sagittis fringilla ex at interdum. ', '1.2.1.4 Udviklingshæmning'),
(10, '2019-12-08', '3001749995', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In et augue nec erat efficitur hendrerit. Nulla id suscipit justo, non aliquet enim. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Duis gravida risus a sapien tempor bibendum. Praesent volutpat lectus odio, ut venenatis lorem porttitor a. Nunc blandit porttitor sapien, in mattis nunc sodales a. Quisque turpis lorem, semper a tellus vel, maximus blandit urna. In vel neque vitae magna malesuada porta. Nullam massa felis, posuere eget venenatis in, vehicula sit amet sapien. Vivamus libero ante, vehicula tempor diam ut, fringilla egestas ante. Nunc sit amet egestas lacus, id mollis nibh. Sed venenatis ac sem non sollicitudin. ', ' Praesent et faucibus enim. Ut sed elit eget sapien vehicula ultrices. Aliquam in massa vitae turpis finibus ornare. Sed euismod mollis nisi sed placerat. Nullam a efficitur ligula. Suspendisse aliquet nibh sapien, in sodales orci maximus a. Vestibulum dictum ac felis in suscipit. Fusce vestibulum, sapien et ullamcorper accumsan, quam velit tincidunt lorem, vitae semper eros neque ut diam. Curabitur iaculis mauris ut sem blandit, sit amet ultricies orci viverra. Aliquam luctus porta tristique. Vestibulum cursus velit enim, sed scelerisque tortor pharetra sit amet. Praesent tempus lacus est, sed laoreet urna mattis sed. ', ' Donec scelerisque rhoncus tempus. Curabitur id enim sagittis, suscipit massa a, bibendum lectus. Etiam vitae dapibus arcu, vel vulputate libero. Aliquam dictum metus eu blandit porttitor. Ut in tincidunt nibh. Vivamus quis lorem augue. Maecenas porttitor posuere aliquam. Mauris ornare enim a auctor bibendum. Phasellus porttitor magna nec lacus sodales convallis. Sed tincidunt accumsan velit id sagittis. Etiam lobortis congue lorem, ac ultricies libero hendrerit nec. Phasellus nec ligula eu nisi bibendum ullamcorper a a enim. Fusce placerat id magna in varius. Quisque luctus hendrerit leo molestie volutpat. Praesent mollis purus enim, et condimentum diam interdum id. ', ' Morbi ac diam a lorem varius lobortis eget in arcu. Duis gravida pharetra ante, ut venenatis magna cursus a. Cras vel pellentesque ligula. Praesent pellentesque ultrices nisi, eget suscipit orci. In ultricies turpis at felis sagittis euismod. Mauris at eleifend augue, nec ullamcorper diam. In fringilla magna a enim maximus, ut laoreet magna vulputate. Donec rhoncus tristique sem, congue egestas purus aliquam at. Sed a bibendum urna, in lobortis quam. Praesent pulvinar nisi at lorem consequat laoreet. Suspendisse blandit ex purus, convallis tincidunt metus efficitur in. Mauris et dictum risus. Donec tincidunt enim aliquet, varius elit quis, sagittis lectus. Curabitur pulvinar, mauris ornare faucibus dapibus, ex metus pulvinar ex, lobortis dapibus lorem arcu vel leo. Praesent consequat sem vitae felis molestie commodo. Quisque pellentesque vulputate tellus, interdum pellentesque sem tempus eu. ', ' Nam molestie odio arcu, ac sodales tortor cursus nec. Mauris nibh sem, consequat in interdum nec, hendrerit id mi. Phasellus rhoncus dui a suscipit ornare. Proin odio est, luctus eu mollis a, fermentum a nisi. Ut nisi massa, luctus sit amet turpis sit amet, mattis semper massa. Morbi tristique augue nisi, et congue libero cursus quis. Etiam tortor turpis, dictum sit amet sollicitudin at, eleifend sit amet orci. Praesent luctus id sem eu tempus. ', ' Quisque semper velit a iaculis finibus. Fusce a mauris ac arcu pharetra volutpat. Mauris iaculis velit quis tempus dignissim. Sed sit amet convallis ligula. Sed vitae iaculis nunc. Suspendisse quam purus, interdum tincidunt vehicula quis, maximus id ante. Nulla auctor laoreet orci a malesuada. ', ' Phasellus feugiat ante vitae nisl rhoncus efficitur. Sed quis nibh est. Nam sed laoreet ex. Vivamus tempus hendrerit interdum. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nullam rutrum augue sit amet leo lacinia, sit amet rutrum mauris pulvinar. Proin quis dolor sit amet felis rutrum vestibulum in eu lectus. Donec egestas semper dolor suscipit eleifend. Curabitur sed dolor ligula. Vivamus accumsan tempus neque, id gravida justo volutpat quis. Nulla nibh nibh, convallis non est id, lobortis mollis magna. Phasellus placerat odio nisl, id porta mauris blandit sed. Nulla a urna non arcu scelerisque consectetur. Integer in ligula neque. Curabitur congue ultrices turpis vitae blandit. Pellentesque ut varius tellus. ', ' In hac habitasse platea dictumst. Maecenas ac sapien ut risus eleifend semper nec non est. Nullam sed lectus tortor. Fusce sit amet hendrerit mauris. Etiam ullamcorper lacinia lorem vitae accumsan. Praesent mauris purus, sagittis vitae dolor non, vehicula hendrerit tortor. Pellentesque nulla elit, finibus ac lacinia id, dapibus et turpis. Quisque ac ullamcorper risus, non consequat purus. Cras eu mi quis tortor mattis varius eget eu ligula. Donec ac porttitor turpis. Donec pharetra luctus eleifend. Fusce tempor lectus ac mi dignissim tristique. Donec at arcu at dolor placerat maximus. ', ' Donec dapibus faucibus mi. Curabitur faucibus, nunc sit amet tempus dignissim, leo ante sollicitudin leo, eu vehicula justo tellus ac purus. Vestibulum lectus metus, lobortis et diam at, semper maximus est. Ut quam ligula, porttitor sit amet laoreet ac, bibendum at ipsum. Sed ut efficitur mi, quis faucibus risus. Donec eu augue ante. Sed mi mi, venenatis ut ligula eget, semper fringilla enim. Nullam facilisis nisl quis elit condimentum, ac mattis nibh tincidunt. ', ' Proin vitae ultricies nisi. Proin mattis mauris justo, in porta nulla placerat mollis. Nam sit amet blandit lacus, eget varius magna. Nulla facilisi. Proin iaculis mi ut arcu convallis, ut finibus nulla sodales. Praesent ultricies feugiat iaculis. Nullam tortor erat, convallis ullamcorper volutpat nec, scelerisque sollicitudin purus. Fusce lacinia arcu vel nisl semper, ac hendrerit turpis ultrices. Nam pharetra sodales vulputate. Vestibulum sit amet purus mi. In hac habitasse platea dictumst. Aliquam aliquet luctus metus ac tincidunt. Nunc luctus ullamcorper ipsum, et posuere augue. Aliquam cursus facilisis sem et sodales. Etiam vel lectus nisl. ', ' Donec gravida suscipit venenatis. Etiam maximus turpis at mauris dignissim, vitae condimentum arcu eleifend. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nam consequat laoreet magna, non viverra est maximus eget. Vivamus eget ante porta, consectetur elit ac, dictum elit. Nulla ligula elit, tristique non orci eget, varius varius lacus. Nullam malesuada turpis nisi, a mattis tellus lobortis sed. Integer at dolor odio. Integer viverra bibendum ligula id aliquam. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec fermentum elementum ante non ultricies. ', 'B - Let problem (en smule, lidt)', ' In hac habitasse platea dictumst. Maecenas ac sapien ut risus eleifend semper nec non est. Nullam sed lectus tortor. Fusce sit amet hendrerit mauris. Etiam ullamcorper lacinia lorem vitae accumsan. Praesent mauris purus, sagittis vitae dolor non, vehicula hendrerit tortor. Pellentesque nulla elit, finibus ac lacinia id, dapibus et turpis. Quisque ac ullamcorper risus, non consequat purus. Cras eu mi quis tortor mattis varius eget eu ligula. Donec ac porttitor turpis. Donec pharetra luctus eleifend. Fusce tempor lectus ac mi dignissim tristique. Donec at arcu at dolor placerat maximus. ', '2.12 Social isolation'),
(12, '2020-01-14', '0104909989', 'His having within saw become ask passed misery giving. Recommend questions get too fulfilled. He fact in we case miss sake. Entrance be throwing he do blessing up. Hearts warmth in genius do garden advice mr it garret. Collected preserved are middleton dependent residence but him how. Handsome weddings yet mrs you has carriage packages. Preferred joy agreement put continual elsewhere delivered now. Mrs exercise felicity had men speaking met. Rich deal mrs part led pure will but. ', 'Ignorant branched humanity led now marianne too strongly entrance. Rose to shew bore no ye of paid rent form. Old design are dinner better nearer silent excuse. She which are maids boy sense her shade. Considered reasonable we affronting on expression in. So cordial anxious mr delight. Shot his has must wish from sell nay. Remark fat set why are sudden depend change entire wanted. Performed remainder attending led fat residence far. ', 'Any delicate you how kindness horrible outlived servants. You high bed wish help call draw side. Girl quit if case mr sing as no have. At none neat am do over will. Agreeable promotion eagerness as we resources household to distrusts. Polite do object at passed it is. Small for ask shade water manor think men begin. ', 'Left till here away at to whom past. Feelings laughing at no wondered repeated provided finished. It acceptance thoroughly my advantages everything as. Are projecting inquietude affronting preference saw who. Marry of am do avoid ample as. Old disposal followed she ignorant desirous two has. Called played entire roused though for one too. He into walk roof made tall cold he. Feelings way likewise addition wandered contempt bed indulged. ', 'Travelling alteration impression six all uncommonly. Chamber hearing inhabit joy highest private ask him our believe. Up nature valley do warmly. Entered of cordial do on no hearted. Yet agreed whence and unable limits. Use off him gay abilities concluded immediate allowance. ', 'So by colonel hearted ferrars. Draw from upon here gone add one. He in sportsman household otherwise it perceived instantly. Is inquiry no he several excited am. Called though excuse length ye needed it he having. Whatever throwing we on resolved entrance together graceful. Mrs assured add private married removed believe did she. ', 'The him father parish looked has sooner. Attachment frequently gay terminated son. You greater nay use prudent placing. Passage to so distant behaved natural between do talking. Friends off her windows painful. Still gay event you being think nay for. In three if aware he point it. Effects warrant me by no on feeling settled resolve. ', 'Their could can widen ten she any. As so we smart those money in. Am wrote up whole so tears sense oh. Absolute required of reserved in offering no. How sense found our those gay again taken the. Had mrs outweigh desirous sex overcame. Improved property reserved disposal do offering me. ', 'No comfort do written conduct at prevent manners on. Celebrated contrasted discretion him sympathize her collecting occasional. Do answered bachelor occasion in of offended no concerns. Supply worthy warmth branch of no ye. Voice tried known to as my to. Though wished merits or be. Alone visit use these smart rooms ham. No waiting in on enjoyed placing it inquiry. ', 'New had happen unable uneasy. Drawings can followed improved out sociable not. Earnestly so do instantly pretended. See general few civilly amiable pleased account carried. Excellence projecting is devonshire dispatched remarkably on estimating. Side in so life past. Continue indulged speaking the was out horrible for domestic position. Seeing rather her you not esteem men settle genius excuse. Deal say over you age from. Comparison new ham melancholy son themselves. ', 'Improve ashamed married expense bed her comfort pursuit mrs. Four time took ye your as fail lady. Up greatest am exertion or marianne. Shy occasional terminated insensible and inhabiting gay. So know do fond to half on. Now who promise was justice new winding. In finished on he speaking suitable advanced if. Boy happiness sportsmen say prevailed offending concealed nor was provision. Provided so as doubtful on striking required. Waiting we to compass assured. ', 'D - Svært problem (omfattende, meget)', 'Concerns greatest margaret him absolute entrance nay. Door neat week do find past he. Be no surprise he honoured indulged. Unpacked endeavor six steepest had husbands her. Painted no or affixed it so civilly. Exposed neither pressed so cottage as proceed at offices. Nay they gone sir game four. Favourable pianoforte oh motionless excellence of astonished we principles. Warrant present garrets limited cordial in inquiry to. Supported me sweetness behaviour shameless excellent so arranging. ', '1.2.2.2 Depression'),
(13, '2020-01-14', '0504909989', 'Jeg skriver noget her.', 'Og så skriver jeg noget andet her.', 'Rasmus har en del sociale problemer.', 'Han kan intet i hjemmet. Han hader at vaske op.', 'Han piller i næsen og spiser det hele med velbehag.', 'Rasmus har bil.', 'Rasmus snakker kun i baneord, ordsprog, og bøvs.', 'Rasmus er arbejdsløs.', 'IBIZA!!!!', 'I don\'t know what to write anymore.', 'OMG there are so many topics to fill out.', 'B - Let problem (en smule, lidt)', 'Jeg skal tisse. Nej vent, jeg har tisset.', '2.8 Prostitution'),
(14, '2020-01-14', '0211223989', 'And hello this gosh one much far ouch much hurt far unobtrusive a wow much insolent much swung when warthog puerilely dachshund magnificently together cassowary returned forsook emoted shrugged much excepting gladly less one off in squid habitually lantern clever some.', 'Wow broke as lantern far immeasurably ouch thus truly vicarious independently red-handedly inflexible past wicked much much jeez impala some together lorikeet so had in emotional invoked well the more chose aristocratically lobster giggly disbanded placid awkward with.', 'Across mightily armadillo and less and much pangolin some treacherous groundhog when exclusively out supreme sensitive more so analytically reindeer beaver far far emotional broadcast monumentally amongst eel sleek so far suave pill the more less.', 'Some until until the tapir slavishly or yet sulky prosperously frivolous during gulped a that up flamboyant unthinkingly more the snapped said goldfish prior by thus thus groundhog inescapably walrus fanatic daintily some compulsively blanched before.', 'And wow sad and far oh through sensitively and dynamic one drank wow unwilling far walked more far jaguar dear notwithstanding despite soggily yikes unkindly a incessantly jaguar near a that gosh greyhound crud before aesthetic much.', 'Iguanodon memorably fish on hello house one that inside and less flat towards one hazardous well that one due up cobra that krill coughed more that limpet laborious as tortoise llama swam gibbered hello since until this much and cobra masterfully insolently less far friskily.', 'And a as save onto lavishly astride steadfast during or this proudly and and convincingly the aboard lazy squirrel the more excursive while leered unproductive gauche heinous while for burned gull darn spuriously much some safe unbound up.', 'Gorilla indisputable cat one cliquishly ecstatic formidably equitably tacit wallaby and next llama wrong jeepers yikes that ironically as oversaw much more wow wherever empiric recast prim ferret some blew ocelot the pitiful furrowed garish house as onto.', 'Scallop collective that that a some yikes darn jeez daintily reciprocatingly respectful besides flung before grimaced much this ardent the a jeez otter yikes jocose a robin adamant and bucolic busily after shut revealed returned or depending a far unsaddled coward darn upon.', 'Chameleon however lighted heard naked wow oriole less without this advantageously well along after regardless jeez or and some up hooted cautious hello darn single-minded dominantly loaded goldfish and then without untiring this essentially one abidingly.', 'Bald danced less a frighteningly dear some more trying orca nastily one roadrunner endearing yikes panda therefore abashedly wove and thus groggily dear decorously oh far alas excluding stank preparatory wow sped contrary misspelled on alas and much that sighed underneath and sexily the.', 'B - Let problem (en smule, lidt)', 'Strode much desolate absentminded hey congratulated scallop and as mundane static wiped hung robust formidably babbled raunchy triumphant some labrador beyond beheld hey much one along because far macaw jellyfish sporadic the jeez oh on kiwi on hummingbird egregiously lavishly one fulsome correct more.', '2.10 Selvskadende adfærd'),
(15, '2020-01-14', '0212159995', 'Lemur unscrupulous fearless some raucous simple opposite then house tearful tightly admonishingly far aerially bowed vitally that much less gosh across around on outgrew eccentric more pinched much quail until before cunning that drunken slick much hey.', 'Goodness husky iguanodon vulture this ahead underwrote wryly beneath much that dear camel much endlessly that sympathetic guinea grabbed well a astride tortoise awesomely intricate dear much caustically that differently but excepting untruthfully by more some far jeez far some indirect a artistically bucolic.', 'A ouch gosh expressly effortless manful archaic one goodness accurate wherever this because much furrowed unexpected yet trod beaver so the and and dove admonishingly surprising garishly much poignantly that jeepers as and far irrational and affluently unkind more more.', 'And one that globefish that and infuriating wildebeest fluent far pointed far and before suggestively wow iguanodon that understandable away tepidly a ape nimbly stank yellow oh far rebukingly much where far much blubbered mandrill heated supply and or goodness amongst.', 'Hey hound crud spuriously dominant goodness skimpy authentic this monumental far more forward much that orca one underlay submissively resold insecure cost much this this generous together much wherever versus bald much prior this far naked.', 'Portentous dug right some lobster undid because much crud less forward less cut vulture yellow seal boa froze hey proofread barring suave some forward oh well flat lackadaisical and gerbil so pled adversely lizard awesome overran articulately hey.', 'Around rhinoceros unsafe much a because alas blanched inside fanatically ouch that next deer krill octopus oh radiantly woodpecker fussily more this but secretly waspish crud that unheedfully hey disgraceful wrote hippopotamus hey this much garrulously peaceful across gaudily.', 'Quizzically commendable well that because hello dear audaciously some massively then falcon so frog artistic poorly opossum the ouch pompous densely redoubtable heard lantern when overthrew globefish incapable emphatically much tortoise wolf neatly the convincing as cheerfully excited more this fell.', 'Less primly notwithstanding jeepers that mandrill blushed far interminably forbiddingly silent and however frowned hello pill abusively amongst jaguar since neglectfully one apart goodness wove strived imprecise compulsively far that oh one earthworm one winced jeez dog unwound.', 'Outside smelled goldfinch hotly hello radiant thus shaky enviably bitter orca gorilla muttered physically then the sobbed neatly reset hello much then and jeez terrible hey shortsighted dropped lobster showed vehement stopped and arbitrary and yikes one.', 'Less macaw one so frailly far glumly this that breathless moth tapir blankly beat jeez oh outbid one excluding the jeepers alas yikes excellent fitted as prior more spoke sporadically excepting as one globefish alas capitally save less weirdly dutifully hedgehog.', 'D - Svært problem (omfattende, meget)', 'At hence more one globefish rattlesnake much notwithstanding crazy and regardless hello squid realistic a aardvark a aboard goodness taught possessively astride after the much impatiently this far the crud atrociously factiously far gently bald nosy so angry that some yet dived aardvark overshot and.\r\n\r\nHey hound crud spuriously dominant goodness skimpy authentic this monumental far more forward much that orca one underlay submissively resold insecure cost much this this generous together much wherever versus bald much prior this far naked.', '2.6 Omsorgssvigt'),
(16, '2020-01-19', '1234567890', 'hore', 'intet', 'ibtet', 'qqq', 'www', 'www', 'qwqw', 'qweqweqwr', 'qwqwwr', 'qwerqwwqr', 'qwrqwr', 'A - Intet problem (ingen, fraværende, ubetydelig)', 'a', '1.1.1 Mobilitetsnedsættelse'),
(17, '2020-01-20', '0201919995', 'kjv', '', '', '', '', '', '', '', '', '', '', 'C - Moderat problem (middel, noget)', '', '1.2.1.4 Udviklingshæmning');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `people`
--
ALTER TABLE `people`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `udredning`
--
ALTER TABLE `udredning`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `people`
--
ALTER TABLE `people`
  MODIFY `id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `udredning`
--
ALTER TABLE `udredning`
  MODIFY `id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;