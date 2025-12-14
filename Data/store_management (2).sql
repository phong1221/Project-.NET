-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th12 14, 2025 lúc 03:52 AM
-- Phiên bản máy phục vụ: 10.4.32-MariaDB
-- Phiên bản PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `store_management`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `categories`
--

CREATE TABLE `categories` (
  `category_id` int(11) NOT NULL,
  `category_name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `categories`
--

INSERT INTO `categories` (`category_id`, `category_name`) VALUES
(1, 'Đồ uống'),
(2, 'Bánh kẹo'),
(3, 'Gia vị'),
(4, 'Đồ gia dụng'),
(5, 'Mỹ phẩm');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `customers`
--

CREATE TABLE `customers` (
  `customer_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `address` text DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `password` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `customers`
--

INSERT INTO `customers` (`customer_id`, `name`, `phone`, `email`, `address`, `created_at`, `password`) VALUES
(1, 'Khách hàng 1', '0909000001', 'kh1@mail.com', 'Địa chỉ 1', '2025-10-02 06:43:46', '123'),
(2, 'Khách hàng 2', '0909000002', 'kh2@mail.com', 'Địa chỉ 2', '2025-10-02 06:43:46', '123'),
(3, 'Khách hàng 3', '0909000003', 'kh3@mail.com', 'Địa chỉ 3', '2025-10-02 06:43:46', '123'),
(4, 'Khách hàng 4', '0909000004', 'kh4@mail.com', 'Địa chỉ 4', '2025-10-02 06:43:46', '123'),
(5, 'Khách hàng 5', '0909000005', 'kh5@mail.com', 'Địa chỉ 5', '2025-10-02 06:43:46', '123'),
(6, 'Khách hàng 6', '0909000006', 'kh6@mail.com', 'Địa chỉ 6', '2025-10-02 06:43:46', '123'),
(7, 'Khách hàng 7', '0909000007', 'kh7@mail.com', 'Địa chỉ 7', '2025-10-02 06:43:46', '123'),
(8, 'Khách hàng 8', '0909000008', 'kh8@mail.com', 'Địa chỉ 8', '2025-10-02 06:43:46', '123'),
(9, 'Khách hàng 9', '0909000009', 'kh9@mail.com', 'Địa chỉ 9', '2025-10-02 06:43:46', '123'),
(10, 'Khách hàng 10', '0909000010', 'kh10@mail.com', 'Địa chỉ 10', '2025-10-02 06:43:46', '123'),
(11, 'Khách hàng 11', '0909000011', 'kh11@mail.com', 'Địa chỉ 11', '2025-10-02 06:43:46', '123'),
(12, 'Khách hàng 12', '0909000012', 'kh12@mail.com', 'Địa chỉ 12', '2025-10-02 06:43:46', '123'),
(13, 'Khách hàng 13', '0909000013', 'kh13@mail.com', 'Địa chỉ 13', '2025-10-02 06:43:46', '123'),
(14, 'Khách hàng 14', '0909000014', 'kh14@mail.com', 'Địa chỉ 14', '2025-10-02 06:43:46', '123'),
(15, 'Khách hàng 15', '0909000015', 'kh15@mail.com', 'Địa chỉ 15', '2025-10-02 06:43:46', '123'),
(16, 'Khách hàng 16', '0909000016', 'kh16@mail.com', 'Địa chỉ 16', '2025-10-02 06:43:46', '123'),
(17, 'Khách hàng 17', '0909000017', 'kh17@mail.com', 'Địa chỉ 17', '2025-10-02 06:43:46', '123'),
(18, 'Khách hàng 18', '0909000018', 'kh18@mail.com', 'Địa chỉ 18', '2025-10-02 06:43:46', '123'),
(19, 'Khách hàng 19', '0909000019', 'kh19@mail.com', 'Địa chỉ 19', '2025-10-02 06:43:46', '123'),
(20, 'Khách hàng 20', '0909000020', 'kh20@mail.com', 'Địa chỉ 20aas', '2025-10-02 06:43:46', '123'),
(21, 'Dang Quang Phong', '1234567890', 'quangthang1212@gmail.com', '14/7 đường Anh Bình , phường 5 , quận 5 , Thành Phố Hồ Chí Minh', '2025-11-11 02:12:46', '123'),
(22, 'Phong', '0941354084', 'quangphong@gmail.com', 'Khánh Hòa\n', '2025-12-14 02:24:24', '123456');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `inventory`
--

CREATE TABLE `inventory` (
  `inventory_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` int(11) DEFAULT 0,
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `inventory`
--

INSERT INTO `inventory` (`inventory_id`, `product_id`, `quantity`, `updated_at`) VALUES
(1, 1, 25, '2025-10-02 06:51:20'),
(2, 2, 168, '2025-10-02 06:51:20'),
(3, 3, 76, '2025-10-02 06:51:20'),
(4, 4, 168, '2025-10-02 06:51:20'),
(5, 5, 90, '2025-10-02 06:51:20'),
(6, 6, 105, '2025-10-02 06:51:20'),
(7, 7, 125, '2025-10-02 06:51:20'),
(8, 8, 37, '2025-10-02 06:51:20'),
(9, 9, 74, '2025-10-02 06:51:20'),
(10, 10, 149, '2025-10-02 06:51:20'),
(11, 11, 69, '2025-10-02 06:51:20'),
(12, 12, 23, '2025-10-02 06:51:20'),
(13, 13, 46, '2025-10-02 06:51:20'),
(14, 14, 144, '2025-10-02 06:51:20'),
(15, 15, 134, '2025-10-02 06:51:20'),
(16, 16, 182, '2025-10-02 06:51:20'),
(17, 17, 99, '2025-10-02 06:51:20'),
(18, 18, 72, '2025-10-02 06:51:20'),
(19, 19, 128, '2025-10-02 06:51:20'),
(20, 20, 123, '2025-10-02 06:51:20'),
(21, 21, 155, '2025-10-02 06:51:20'),
(22, 22, 78, '2025-10-02 06:51:20'),
(23, 23, 166, '2025-10-02 06:51:20'),
(24, 24, 117, '2025-10-02 06:51:20'),
(25, 25, 168, '2025-10-02 06:51:20'),
(26, 26, 197, '2025-10-02 06:51:20'),
(27, 27, 36, '2025-10-02 06:51:20'),
(28, 28, 145, '2025-10-02 06:51:20'),
(29, 29, 61, '2025-10-02 06:51:20'),
(30, 30, 139, '2025-10-02 06:51:20'),
(31, 31, 47, '2025-10-02 06:51:20'),
(32, 32, 154, '2025-10-02 06:51:20'),
(33, 33, 194, '2025-10-02 06:51:20'),
(34, 34, 41, '2025-10-02 06:51:20'),
(35, 35, 154, '2025-10-02 06:51:20'),
(36, 36, 71, '2025-10-02 06:51:20'),
(37, 37, 49, '2025-10-02 06:51:20'),
(38, 38, 165, '2025-10-02 06:51:20'),
(39, 39, 73, '2025-10-02 06:51:20'),
(40, 40, 176, '2025-10-02 06:51:20'),
(41, 41, 41, '2025-10-02 06:51:20'),
(42, 42, 34, '2025-10-02 06:51:20'),
(43, 43, 175, '2025-10-02 06:51:20'),
(44, 44, 59, '2025-10-02 06:51:20'),
(45, 45, 198, '2025-10-02 06:51:20'),
(46, 46, 106, '2025-10-02 06:51:20'),
(47, 47, 99, '2025-10-02 06:51:20'),
(48, 48, 55, '2025-10-02 06:51:20'),
(49, 49, 62, '2025-10-02 06:51:20'),
(50, 50, 33, '2025-10-02 06:51:20');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `orders`
--

CREATE TABLE `orders` (
  `order_id` int(11) NOT NULL,
  `customer_id` int(11) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `promo_id` int(11) DEFAULT NULL,
  `order_date` timestamp NOT NULL DEFAULT current_timestamp(),
  `status` enum('pending','paid','canceled') DEFAULT 'pending',
  `total_amount` decimal(10,2) DEFAULT NULL,
  `discount_amount` decimal(10,2) DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `orders`
--

INSERT INTO `orders` (`order_id`, `customer_id`, `user_id`, `promo_id`, `order_date`, `status`, `total_amount`, `discount_amount`) VALUES
(1, 1, 1, NULL, '2025-10-01 23:50:24', 'paid', 1192330.00, 0.00),
(2, 2, 2, NULL, '2025-10-01 23:50:24', 'paid', 1731608.00, 0.00),
(3, 3, 1, NULL, '2025-10-01 23:50:24', 'paid', 720782.00, 0.00),
(4, 4, 2, NULL, '2025-10-01 23:50:24', 'canceled', 0.00, 0.00),
(5, 5, 1, NULL, '2025-10-01 23:50:24', 'paid', 94180.00, 0.00),
(6, 6, 3, NULL, '2025-10-01 23:50:24', 'paid', 3788671.00, 0.00),
(7, 7, 1, 1, '2025-10-01 23:50:24', 'paid', 455639.11, 45563.91),
(8, 8, 2, NULL, '2025-10-01 23:50:24', 'paid', 1543526.10, 0.00),
(9, 9, 1, NULL, '2025-10-01 23:50:24', 'paid', 2484051.00, 0.00),
(10, 10, 3, NULL, '2025-10-01 23:50:24', 'paid', 970239.00, 0.00),
(11, 11, 2, NULL, '2025-10-01 23:50:24', 'paid', 1532741.00, 0.00),
(12, 12, 1, NULL, '2025-10-01 23:50:24', 'paid', 1785354.00, 0.00),
(13, 13, 3, NULL, '2025-10-01 23:50:24', 'paid', 1488276.00, 0.00),
(14, 14, 1, NULL, '2025-10-01 23:50:24', 'paid', 2846096.00, 0.00),
(15, 15, 2, NULL, '2025-10-01 23:50:24', 'paid', 158100.00, 0.00),
(16, 16, 1, NULL, '2025-10-01 23:50:24', 'paid', 974090.00, 0.00),
(17, 17, 3, NULL, '2025-10-01 23:50:24', 'paid', 467148.00, 0.00),
(18, 18, 2, NULL, '2025-10-01 23:50:24', 'paid', 394342.00, 0.00),
(19, 19, 1, 4, '2025-10-01 23:50:24', 'paid', 1965636.94, 294545.54),
(20, 20, 3, NULL, '2025-10-01 23:50:24', 'paid', 2889813.00, 0.00),
(21, 1, 1, NULL, '2025-10-01 23:50:24', 'paid', 2288406.00, 0.00),
(22, 2, 2, NULL, '2025-10-01 23:50:24', 'paid', 331008.00, 0.00),
(23, 3, 1, 1, '2025-10-01 23:50:24', 'paid', 2035137.06, 203513.71),
(24, 4, 3, 1, '2025-10-01 23:50:24', 'paid', 1075425.67, 107542.57),
(25, 5, 2, NULL, '2025-10-01 23:50:24', 'paid', 293847.00, 0.00),
(26, 6, 1, 1, '2025-10-01 23:50:24', 'paid', 231696.00, 23169.60),
(27, 7, 3, NULL, '2025-10-01 23:50:24', 'paid', 933199.00, 0.00),
(28, 8, 1, NULL, '2025-10-01 23:50:24', 'paid', 2609123.00, 0.00),
(29, 9, 2, 1, '2025-10-01 23:50:24', 'paid', 2138926.22, 213892.62),
(30, 10, 1, NULL, '2025-10-01 23:50:24', 'paid', 2912134.00, 0.00),
(31, NULL, 1, NULL, '2025-12-14 01:23:29', 'paid', 351670.00, 0.00),
(32, 22, NULL, NULL, '2025-12-14 02:24:41', 'paid', 114807.00, 0.00),
(33, 22, NULL, NULL, '2025-12-14 02:49:39', 'paid', 415725.00, 0.00);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `order_items`
--

CREATE TABLE `order_items` (
  `order_item_id` int(11) NOT NULL,
  `order_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `quantity` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `order_items`
--

INSERT INTO `order_items` (`order_item_id`, `order_id`, `product_id`, `quantity`, `price`, `subtotal`) VALUES
(1, 1, 23, 2, 31265.00, 62530.00),
(2, 1, 5, 2, 205683.00, 411366.00),
(3, 1, 47, 1, 477948.00, 477948.00),
(4, 1, 25, 2, 170243.00, 340486.00),
(5, 2, 39, 1, 447059.00, 447059.00),
(6, 2, 14, 1, 51108.00, 51108.00),
(7, 2, 46, 3, 411147.00, 1233441.00),
(8, 3, 18, 3, 202167.00, 606501.00),
(9, 3, 34, 1, 44219.00, 44219.00),
(10, 3, 26, 3, 23354.00, 70062.00),
(11, 4, 24, 2, 10843.00, 21686.00),
(12, 5, 9, 1, 94180.00, 94180.00),
(13, 6, 18, 3, 186886.00, 560658.00),
(14, 6, 22, 2, 199267.00, 398534.00),
(15, 6, 42, 3, 215726.00, 647178.00),
(16, 6, 17, 3, 474268.00, 1422804.00),
(17, 6, 20, 3, 286499.00, 859497.00),
(18, 7, 8, 2, 256297.00, 512594.00),
(19, 8, 42, 1, 355116.00, 355116.00),
(20, 8, 43, 2, 129224.00, 258448.00),
(21, 8, 31, 3, 367155.00, 1101465.00),
(22, 9, 17, 2, 48755.00, 97510.00),
(23, 9, 12, 2, 381904.00, 763808.00),
(24, 9, 43, 2, 167445.00, 334890.00),
(25, 9, 19, 3, 429281.00, 1287843.00),
(26, 10, 25, 1, 232635.00, 232635.00),
(27, 10, 1, 2, 245362.00, 490724.00),
(28, 10, 23, 2, 127233.00, 254466.00),
(29, 10, 49, 2, 46207.00, 92414.00),
(30, 11, 3, 2, 347879.00, 695758.00),
(31, 11, 23, 3, 130215.00, 390645.00),
(32, 11, 4, 1, 64761.00, 64761.00),
(33, 11, 33, 1, 240159.00, 240159.00),
(34, 11, 7, 1, 141418.00, 141418.00),
(35, 12, 40, 2, 455428.00, 910856.00),
(36, 12, 46, 2, 75412.00, 150824.00),
(37, 12, 34, 2, 189856.00, 379712.00),
(38, 12, 25, 3, 114654.00, 343962.00),
(39, 13, 24, 2, 143251.00, 286502.00),
(40, 13, 23, 2, 381347.00, 762694.00),
(41, 13, 18, 2, 179146.00, 358292.00),
(42, 13, 9, 2, 90394.00, 180788.00),
(43, 14, 24, 2, 327016.00, 654032.00),
(44, 14, 2, 1, 403478.00, 403478.00),
(45, 14, 27, 3, 404474.00, 1213422.00),
(46, 14, 4, 2, 312582.00, 625164.00),
(47, 15, 18, 1, 105328.00, 105328.00),
(48, 15, 27, 2, 17303.00, 34606.00),
(49, 15, 50, 2, 23033.00, 46066.00),
(50, 16, 15, 1, 43160.00, 43160.00),
(51, 16, 16, 2, 18541.00, 37082.00),
(52, 16, 44, 1, 492698.00, 492698.00),
(53, 16, 41, 1, 451150.00, 451150.00),
(54, 17, 42, 1, 467148.00, 467148.00),
(55, 18, 30, 1, 64334.00, 64334.00),
(56, 18, 11, 1, 178454.00, 178454.00),
(57, 18, 20, 3, 50518.00, 151554.00),
(58, 19, 16, 1, 89280.00, 89280.00),
(59, 19, 23, 3, 404655.00, 1213965.00),
(60, 19, 11, 2, 331196.00, 662392.00),
(61, 20, 49, 1, 367325.00, 367325.00),
(62, 20, 32, 2, 264392.00, 528784.00),
(63, 20, 19, 3, 345903.00, 1037709.00),
(64, 20, 17, 2, 392028.00, 784056.00),
(65, 20, 19, 1, 171939.00, 171939.00),
(66, 21, 11, 3, 227666.00, 682998.00),
(67, 21, 25, 2, 436122.00, 872244.00),
(68, 21, 48, 1, 340400.00, 340400.00),
(69, 21, 10, 2, 58482.00, 116964.00),
(70, 21, 4, 2, 137900.00, 275800.00),
(71, 22, 40, 2, 165504.00, 331008.00),
(72, 23, 1, 2, 296698.00, 593396.00),
(73, 23, 16, 3, 384657.00, 1153971.00),
(74, 23, 40, 3, 135828.00, 407484.00),
(75, 24, 3, 3, 379562.00, 1138686.00),
(76, 25, 9, 1, 22063.00, 22063.00),
(77, 25, 16, 2, 185892.00, 371784.00),
(78, 26, 47, 2, 130329.00, 260658.00),
(79, 27, 37, 1, 448581.00, 448581.00),
(80, 27, 23, 1, 484618.00, 484618.00),
(81, 28, 20, 3, 357837.00, 1073511.00),
(82, 28, 34, 1, 161219.00, 161219.00),
(83, 28, 1, 3, 458131.00, 1374393.00),
(84, 29, 28, 1, 485514.00, 485514.00),
(85, 29, 7, 3, 487044.00, 1461132.00),
(86, 29, 42, 1, 235885.00, 235885.00),
(87, 29, 38, 1, 223761.00, 223761.00),
(88, 30, 25, 1, 426943.00, 426943.00),
(89, 30, 11, 3, 130209.00, 390627.00),
(90, 30, 5, 2, 73116.00, 146232.00),
(91, 30, 46, 2, 272220.00, 544440.00),
(92, 30, 23, 3, 467964.00, 1403892.00),
(93, 31, 4, 1, 351670.00, 351670.00),
(94, 32, 2, 1, 114807.00, 114807.00),
(95, 33, 3, 1, 415725.00, 415725.00);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `payments`
--

CREATE TABLE `payments` (
  `payment_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `amount` decimal(10,2) NOT NULL,
  `payment_method` enum('cash','card','bank_transfer','e-wallet') DEFAULT 'cash',
  `payment_date` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `payments`
--

INSERT INTO `payments` (`payment_id`, `order_id`, `amount`, `payment_method`, `payment_date`) VALUES
(1, 1, 1192330.00, 'cash', '2025-10-02 06:50:24'),
(2, 2, 1731608.00, 'e-wallet', '2025-10-02 06:50:24'),
(3, 3, 720782.00, 'e-wallet', '2025-10-02 06:50:24'),
(4, 4, 0.00, 'card', '2025-10-02 06:50:24'),
(5, 5, 94180.00, 'cash', '2025-10-02 06:50:24'),
(6, 6, 3788671.00, 'cash', '2025-10-02 06:50:24'),
(7, 7, 410075.20, 'e-wallet', '2025-10-02 06:50:24'),
(8, 8, 1543526.10, 'cash', '2025-10-02 06:50:24'),
(9, 9, 2484051.00, 'cash', '2025-10-02 06:50:24'),
(10, 10, 970239.00, 'card', '2025-10-02 06:50:24'),
(11, 11, 1532741.00, 'e-wallet', '2025-10-02 06:50:24'),
(12, 12, 1785354.00, 'card', '2025-10-02 06:50:24'),
(13, 13, 1488276.00, 'card', '2025-10-02 06:50:24'),
(14, 14, 2846096.00, 'cash', '2025-10-02 06:50:24'),
(15, 15, 158100.00, 'card', '2025-10-02 06:50:24'),
(16, 16, 974090.00, 'cash', '2025-10-02 06:50:24'),
(17, 17, 467148.00, 'cash', '2025-10-02 06:50:24'),
(18, 18, 394342.00, 'e-wallet', '2025-10-02 06:50:24'),
(19, 19, 1670791.45, 'card', '2025-10-02 06:50:24'),
(20, 20, 2889813.00, 'card', '2025-10-02 06:50:24'),
(21, 21, 2288406.00, 'cash', '2025-10-02 06:50:24'),
(22, 22, 331008.00, 'e-wallet', '2025-10-02 06:50:24'),
(23, 23, 1831623.35, 'cash', '2025-10-02 06:50:24'),
(24, 24, 967883.10, 'e-wallet', '2025-10-02 06:50:24'),
(25, 25, 293847.00, 'cash', '2025-10-02 06:50:24'),
(26, 26, 208526.40, 'cash', '2025-10-02 06:50:24'),
(27, 27, 933199.00, 'cash', '2025-10-02 06:50:24'),
(28, 28, 2609123.00, 'card', '2025-10-02 06:50:24'),
(29, 29, 1925033.60, 'cash', '2025-10-02 06:50:24'),
(30, 30, 2912134.00, 'card', '2025-10-02 06:50:24'),
(31, 31, 351670.00, 'cash', '2025-12-14 01:23:30'),
(32, 32, 114807.00, '', '2025-12-14 02:24:41'),
(33, 33, 415725.00, '', '2025-12-14 02:50:17');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `products`
--

CREATE TABLE `products` (
  `product_id` int(11) NOT NULL,
  `category_id` int(11) DEFAULT NULL,
  `supplier_id` int(11) DEFAULT NULL,
  `product_name` varchar(100) NOT NULL,
  `barcode` varchar(50) DEFAULT NULL,
  `price` decimal(10,2) NOT NULL,
  `unit` varchar(20) DEFAULT 'pcs',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `products`
--

INSERT INTO `products` (`product_id`, `category_id`, `supplier_id`, `product_name`, `barcode`, `price`, `unit`, `created_at`) VALUES
(1, 2, 1, 'Coca Cola lon', '8900000000001', 314838.00, 'hộp', '2025-10-02 06:49:25'),
(2, 1, 3, 'Pepsi lon', '8900000000002', 114807.00, 'cái', '2025-10-02 06:49:25'),
(3, 3, 3, 'Trà Xanh 0 độ', '8900000000003', 415725.00, 'tuýp', '2025-10-02 06:49:25'),
(4, 2, 1, 'Sting dâu', '8900000000004', 351670.00, 'cái', '2025-10-02 06:49:25'),
(5, 3, 2, 'Red Bull', '8900000000005', 402179.00, 'lon', '2025-10-02 06:49:25'),
(6, 2, 2, 'Bánh Oreo', '8900000000006', 209283.00, 'chai', '2025-10-02 06:49:25'),
(7, 5, 3, 'Bánh Chocopie', '8900000000007', 212528.00, 'lon', '2025-10-02 06:49:25'),
(8, 1, 2, 'Kẹo Alpenliebe', '8900000000008', 34313.00, 'lon', '2025-10-02 06:49:25'),
(9, 5, 1, 'Kẹo bạc hà', '8900000000009', 316289.00, 'cái', '2025-10-02 06:49:25'),
(10, 1, 2, 'Socola KitKat', '8900000000010', 139959.00, 'chai', '2025-10-02 06:49:25'),
(11, 5, 1, 'Nước mắm Nam Ngư', '8900000000011', 51792.00, 'chai', '2025-10-02 06:49:25'),
(12, 2, 2, 'Nước tương Maggi', '8900000000012', 462539.00, 'lon', '2025-10-02 06:49:25'),
(13, 5, 3, 'Muối i-ốt', '8900000000013', 173302.00, 'cái', '2025-10-02 06:49:25'),
(14, 1, 1, 'Bột ngọt Ajinomoto', '8900000000014', 443069.00, 'cái', '2025-10-02 06:49:25'),
(15, 2, 2, 'Dầu ăn Tường An', '8900000000015', 281354.00, 'tuýp', '2025-10-02 06:49:25'),
(16, 2, 1, 'Nồi cơm điện', '8900000000016', 405347.00, 'hộp', '2025-10-02 06:49:25'),
(17, 1, 3, 'Ấm siêu tốc', '8900000000017', 113087.00, 'chai', '2025-10-02 06:49:25'),
(18, 3, 2, 'Quạt máy', '8900000000018', 69968.00, 'hộp', '2025-10-02 06:49:25'),
(19, 4, 1, 'Bếp gas mini', '8900000000019', 416845.00, 'lon', '2025-10-02 06:49:25'),
(20, 3, 3, 'Máy xay sinh tố', '8900000000020', 334564.00, 'hộp', '2025-10-02 06:49:25'),
(21, 1, 1, 'Sữa rửa mặt Hazeline', '8900000000021', 188475.00, 'lon', '2025-10-02 06:49:25'),
(22, 4, 1, 'Kem dưỡng da Ponds', '8900000000022', 413840.00, 'hộp', '2025-10-02 06:49:25'),
(23, 3, 3, 'Dầu gội Sunsilk', '8900000000023', 158950.00, 'tuýp', '2025-10-02 06:49:25'),
(24, 4, 2, 'Sữa tắm Dove', '8900000000024', 336928.00, 'chai', '2025-10-02 06:49:25'),
(25, 1, 1, 'Nước hoa Romano', '8900000000025', 352508.00, 'cái', '2025-10-02 06:49:25'),
(26, 1, 1, 'Cà phê G7', '8900000000026', 201228.00, 'lon', '2025-10-02 06:49:25'),
(27, 2, 1, 'Trà Lipton', '8900000000027', 38039.00, 'cái', '2025-10-02 06:49:25'),
(28, 2, 3, 'Sữa Vinamilk', '8900000000028', 252845.00, 'chai', '2025-10-02 06:49:25'),
(29, 3, 1, 'Sữa TH True Milk', '8900000000029', 35278.00, 'hộp', '2025-10-02 06:49:25'),
(30, 3, 2, 'Nước suối Lavie', '8900000000030', 331637.00, 'lon', '2025-10-02 06:49:25'),
(31, 5, 3, 'Khăn giấy Tempo', '8900000000031', 102525.00, 'chai', '2025-10-02 06:49:25'),
(32, 4, 3, 'Giấy vệ sinh Pulppy', '8900000000032', 495429.00, 'chai', '2025-10-02 06:49:25'),
(33, 3, 2, 'Bình nước Lock&Lock', '8900000000033', 354771.00, 'gói', '2025-10-02 06:49:25'),
(34, 2, 1, 'Hộp nhựa Tupperware', '8900000000034', 297415.00, 'cái', '2025-10-02 06:49:25'),
(35, 1, 3, 'Dao Inox', '8900000000035', 47523.00, 'hộp', '2025-10-02 06:49:25'),
(36, 3, 1, 'Bàn chải Colgate', '8900000000036', 136417.00, 'chai', '2025-10-02 06:49:25'),
(37, 2, 2, 'Kem đánh răng P/S', '8900000000037', 93713.00, 'hộp', '2025-10-02 06:49:25'),
(38, 2, 3, 'Nước súc miệng Listerine', '8900000000038', 223906.00, 'gói', '2025-10-02 06:49:25'),
(39, 1, 2, 'Bông tẩy trang', '8900000000039', 317819.00, 'tuýp', '2025-10-02 06:49:25'),
(40, 4, 1, 'Khẩu trang 3M', '8900000000040', 464252.00, 'gói', '2025-10-02 06:49:25'),
(41, 3, 1, 'Bánh mì sandwich', '8900000000041', 279350.00, 'cái', '2025-10-02 06:49:25'),
(42, 5, 2, 'Mì gói Hảo Hảo', '8900000000042', 9413.00, 'hộp', '2025-10-02 06:49:25'),
(43, 1, 2, 'Mì Omachi', '8900000000043', 26616.00, 'hộp', '2025-10-02 06:49:25'),
(44, 5, 2, 'Bún khô', '8900000000044', 350911.00, 'gói', '2025-10-02 06:49:25'),
(45, 3, 1, 'Phở ăn liền', '8900000000045', 407779.00, 'tuýp', '2025-10-02 06:49:25'),
(46, 1, 1, 'Nước ngọt Sprite', '8900000000046', 230083.00, 'hộp', '2025-10-02 06:49:25'),
(47, 1, 3, 'Trà sữa đóng chai', '8900000000047', 15130.00, 'cái', '2025-10-02 06:49:25'),
(48, 3, 3, 'Snack Oishi', '8900000000048', 43415.00, 'cái', '2025-10-02 06:49:25'),
(49, 4, 2, 'Snack Lays', '8900000000049', 83536.00, 'tuýp', '2025-10-02 06:49:25'),
(50, 1, 2, 'Kẹo dẻo Haribo', '8900000000050', 328680.00, 'cái', '2025-10-02 06:49:25');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `promotions`
--

CREATE TABLE `promotions` (
  `promo_id` int(11) NOT NULL,
  `promo_code` varchar(50) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `discount_type` enum('percent','fixed') NOT NULL,
  `discount_value` decimal(10,2) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `min_order_amount` decimal(10,2) DEFAULT 0.00,
  `usage_limit` int(11) DEFAULT 0,
  `used_count` int(11) DEFAULT 0,
  `status` enum('active','inactive') DEFAULT 'active',
  `created_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `promotions`
--

INSERT INTO `promotions` (`promo_id`, `promo_code`, `description`, `discount_type`, `discount_value`, `start_date`, `end_date`, `min_order_amount`, `usage_limit`, `used_count`, `status`, `created_at`) VALUES
(1, 'SALE10', 'Giảm 10% cho mọi đơn hàng', 'percent', 10.00, '2025-01-01', '2025-12-31', 0.00, 0, 0, 'active', '2025-12-14 00:38:16'),
(2, 'FREESHIP50K', 'Giảm 50,000 cho đơn từ 300,000 trở lên', 'fixed', 50000.00, '2025-03-01', '2025-12-31', 300000.00, 500, 0, 'active', '2025-12-14 00:38:16'),
(3, 'NEWUSER', 'Giảm 20% cho khách hàng mới', 'percent', 20.00, '2025-01-01', '2025-06-30', 0.00, 1, 0, 'active', '2025-12-14 00:38:16'),
(4, 'SUMMER15', 'Giảm 15% mùa hè', 'percent', 15.00, '2025-06-01', '2025-08-31', 50000.00, 1000, 0, 'active', '2025-12-14 00:38:16'),
(5, 'VIP100K', 'Giảm 100,000 cho đơn từ 1 triệu', 'fixed', 100000.00, '2025-01-01', '2025-12-31', 1000000.00, 200, 0, 'active', '2025-12-14 00:38:16');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `suppliers`
--

CREATE TABLE `suppliers` (
  `supplier_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `address` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `suppliers`
--

INSERT INTO `suppliers` (`supplier_id`, `name`, `phone`, `email`, `address`) VALUES
(1, 'Công ty ABC', '0909123456', 'abc@gmail.com', 'Hà Nội'),
(2, 'Công ty XYZ', '0912123456', 'xyz@gmail.com', 'TP HCM'),
(3, 'Công ty 123', '0933123456', '123@gmail.com', 'Đà Nẵng');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `full_name` varchar(100) DEFAULT NULL,
  `role` enum('admin','staff','customer') DEFAULT 'staff',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `users`
--

INSERT INTO `users` (`user_id`, `username`, `password`, `full_name`, `role`, `created_at`) VALUES
(1, 'admin', '123456', 'Quản trị viên', 'admin', '2025-10-02 06:43:46'),
(2, 'staff01', '123456', 'Nguyễn Văn A', 'staff', '2025-10-02 06:43:46'),
(3, 'staff02', '123456', 'Lê Thị B', 'staff', '2025-10-02 06:43:46'),
(4, 'phong', '123456', 'Đặng Quang Phong', 'customer', '2025-12-14 02:46:23');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`category_id`);

--
-- Chỉ mục cho bảng `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`customer_id`);

--
-- Chỉ mục cho bảng `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`inventory_id`);

--
-- Chỉ mục cho bảng `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `fk_orders_customer` (`customer_id`),
  ADD KEY `fk_orders_user` (`user_id`),
  ADD KEY `fk_orders_promo` (`promo_id`);

--
-- Chỉ mục cho bảng `order_items`
--
ALTER TABLE `order_items`
  ADD PRIMARY KEY (`order_item_id`);

--
-- Chỉ mục cho bảng `payments`
--
ALTER TABLE `payments`
  ADD PRIMARY KEY (`payment_id`),
  ADD KEY `fk_payments_order` (`order_id`);

--
-- Chỉ mục cho bảng `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`),
  ADD UNIQUE KEY `barcode` (`barcode`);

--
-- Chỉ mục cho bảng `promotions`
--
ALTER TABLE `promotions`
  ADD PRIMARY KEY (`promo_id`),
  ADD UNIQUE KEY `promo_code` (`promo_code`);

--
-- Chỉ mục cho bảng `suppliers`
--
ALTER TABLE `suppliers`
  ADD PRIMARY KEY (`supplier_id`);

--
-- Chỉ mục cho bảng `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `categories`
--
ALTER TABLE `categories`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT cho bảng `customers`
--
ALTER TABLE `customers`
  MODIFY `customer_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT cho bảng `inventory`
--
ALTER TABLE `inventory`
  MODIFY `inventory_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

--
-- AUTO_INCREMENT cho bảng `orders`
--
ALTER TABLE `orders`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT cho bảng `order_items`
--
ALTER TABLE `order_items`
  MODIFY `order_item_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=96;

--
-- AUTO_INCREMENT cho bảng `payments`
--
ALTER TABLE `payments`
  MODIFY `payment_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT cho bảng `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

--
-- AUTO_INCREMENT cho bảng `promotions`
--
ALTER TABLE `promotions`
  MODIFY `promo_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT cho bảng `suppliers`
--
ALTER TABLE `suppliers`
  MODIFY `supplier_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT cho bảng `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `fk_orders_customer` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_orders_promo` FOREIGN KEY (`promo_id`) REFERENCES `promotions` (`promo_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_orders_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `payments`
--
ALTER TABLE `payments`
  ADD CONSTRAINT `fk_payments_order` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
