-- Insert data into Device table
INSERT INTO `Device` (`Id`, `Name`, `Ip`, `Status`, `Discriminator`, `TransmitterId`, `Url`) VALUES
(1, 'Debian 1', NULL, 1, 'Transmitter', NULL, 'https://upload.wikimedia.org/wikipedia/commons/f/fc/Debian_12_Bookworm_GNOME_Desktop_English.png'),
(2, 'Fedora 1', NULL, 1, 'Transmitter', NULL, 'https://upload.wikimedia.org/wikipedia/commons/8/82/Fedora_Workstation_40.png'),
(3, 'Arch 1', NULL, 1, 'Transmitter', NULL, 'https://upload.wikimedia.org/wikipedia/commons/6/61/Arch_Linux_ARM-Asahi_Linux_Desktop_English_07-2023.png'),
(4, 'WindowsXP 1', NULL, 1, 'Transmitter', NULL, 'https://upload.wikimedia.org/wikipedia/en/6/64/Windows_XP_Luna.png'),
(5, 'Receptor 1', NULL, 1, 'Receiver', 1, NULL),
(6, 'Receptor 2', NULL, 1, 'Receiver', 1, NULL),
(7, 'Receptor 3', NULL, 1, 'Receiver', 2, NULL);

-- Insert data into Profile table
INSERT INTO `Profile` (`Id`, `Name`) VALUES
(1, 'Profile 1'),
(2, 'Profile 2');

-- Insert data into Connection table
INSERT INTO `Connection` (`Id`, `TransmitterId`, `ReceiverId`, `ProfileId`) VALUES
(1, 1, 5, 1),
(2, 1, 6, 1),
(3, 2, 7, 1),
(4, 3, 5, 2),
(5, 4, 6, 2),
(6, 2, 7, 2);