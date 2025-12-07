-- ======================
-- DATABASE
-- ======================
CREATE DATABASE IF NOT EXISTS school_management_c
CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE school_management_c;

-- ======================
-- TABLES
-- ======================
CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50),
    password VARCHAR(255),
    fullname VARCHAR(100),
    email VARCHAR(100),
    phone VARCHAR(15),
    role_id VARCHAR(50),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE students (
    student_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    dob DATE,
    gender ENUM('Male','Female'),
    address TEXT,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE grade_levels (
    grade_id INT AUTO_INCREMENT PRIMARY KEY,
    grade_name VARCHAR(20)
);

CREATE TABLE classes (
    class_id INT AUTO_INCREMENT PRIMARY KEY,
    class_name VARCHAR(50),
    grade_id INT,
    FOREIGN KEY (grade_id) REFERENCES grade_levels(grade_id)
);

CREATE TABLE academic_years (
    year_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(20),
    start_date DATE,
    end_date DATE
);

CREATE TABLE semesters (
    semester_id INT AUTO_INCREMENT PRIMARY KEY,
    year_id INT,
    name VARCHAR(20),
    start_date DATE,
    end_date DATE,
    FOREIGN KEY (year_id) REFERENCES academic_years(year_id)
);

CREATE TABLE subjects (
    subject_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100)
);

CREATE TABLE teacher_assignments (
    assign_id INT AUTO_INCREMENT PRIMARY KEY,
    teacher_id INT,
    subject_id INT,
    class_id INT,
    semester_id INT,
    periods INT,
    FOREIGN KEY (teacher_id) REFERENCES users(user_id),
    FOREIGN KEY (subject_id) REFERENCES subjects(subject_id),
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id)
);

CREATE TABLE timetable (
    id INT AUTO_INCREMENT PRIMARY KEY,
    class_id INT,
    subject_id INT,
    teacher_id INT,
    semester_id INT,
    day ENUM('Mon','Tue','Wed','Thu','Fri','Sat'),
    period INT,
    room VARCHAR(50),
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (subject_id) REFERENCES subjects(subject_id),
    FOREIGN KEY (teacher_id) REFERENCES users(user_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id)
);

CREATE TABLE tuition (
    tuition_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    description VARCHAR(255),
    name VARCHAR(255),
    amount DECIMAL(10,2),
    semester_id INT,
    due_date DATE,
    status ENUM('unpaid','paid'),
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id)
);

CREATE TABLE student_evaluations (
    evaluation_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    class_id INT,
    semester_id INT,
    conduct ENUM('Tốt','Khá','Trung Bình','Yếu'),
    teacher_comment TEXT,
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id),
    UNIQUE KEY unique_eval (student_id, class_id, semester_id)
);

CREATE TABLE student_class (
    id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    class_id INT,
    school_year_id INT,
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (school_year_id) REFERENCES academic_years(year_id)
);

CREATE TABLE scores (
    score_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    assign_id INT,
    score_type ENUM('oral','quiz15','quiz45','midterm','final','ave'),
    score_value FLOAT,
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (assign_id) REFERENCES teacher_assignments(assign_id)
);

CREATE TABLE school_info (
    school_id INT AUTO_INCREMENT PRIMARY KEY,
    school_name VARCHAR(200),
    address TEXT,
    phone VARCHAR(20)
);

CREATE TABLE notifications (
    id INT AUTO_INCREMENT PRIMARY KEY,
    sender_id INT,
    target_role ENUM('teacher','student','parent','all'),
    title VARCHAR(200),
    message TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (sender_id) REFERENCES users(user_id)
);

CREATE TABLE homeroom_assignments (
    assign_id INT AUTO_INCREMENT PRIMARY KEY,
    class_id INT,
    teacher_id INT,
    year_id INT,
    assigned_date DATE,
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (teacher_id) REFERENCES users(user_id),
    FOREIGN KEY (year_id) REFERENCES academic_years(year_id)
);

CREATE TABLE grade_rank (
    id INT AUTO_INCREMENT PRIMARY KEY,
    rank_name VARCHAR(50),
    min_score FLOAT,
    max_score FLOAT
);

CREATE TABLE comments (
    id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    teacher_id INT,
    semester_id INT,
    comment_text TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (teacher_id) REFERENCES users(user_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id)
);

-- ======================================
-- INSERT DATA
-- ======================================
-- USERS: 5 admin, 5 student, 5 gvcn, 5 gvbm
INSERT INTO users (username,password,fullname,email,phone,role_id) VALUES
('admin1','123','Admin One','admin1@mail.com','0900000001','admin'),
('admin2','123','Admin Two','admin2@mail.com','0900000002','admin'),
('admin3','123','Admin Three','admin3@mail.com','0900000003','admin'),
('admin4','123','Admin Four','admin4@mail.com','0900000004','admin'),
('admin5','123','Admin Five','admin5@mail.com','0900000005','admin'),

('student1','123','Student One','st1@mail.com','0911111111','student'),
('student2','123','Student Two','st2@mail.com','0911111112','student'),
('student3','123','Student Three','st3@mail.com','0911111113','student'),
('student4','123','Student Four','st4@mail.com','0911111114','student'),
('student5','123','Student Five','st5@mail.com','0911111115','student'),

('gvcn1','123','GVCN One','gvcn1@mail.com','0922222221','gvcn'),
('gvcn2','123','GVCN Two','gvcn2@mail.com','0922222222','gvcn'),
('gvcn3','123','GVCN Three','gvcn3@mail.com','0922222223','gvcn'),
('gvcn4','123','GVCN Four','gvcn4@mail.com','0922222224','gvcn'),
('gvcn5','123','GVCN Five','gvcn5@mail.com','0922222225','gvcn'),

('gvbm1','123','GVBM One','gvbm1@mail.com','0933333331','gvbm'),
('gvbm2','123','GVBM Two','gvbm2@mail.com','0933333332','gvbm'),
('gvbm3','123','GVBM Three','gvbm3@mail.com','0933333333','gvbm'),
('gvbm4','123','GVBM Four','gvbm4@mail.com','0933333334','gvbm'),
('gvbm5','123','GVBM Five','gvbm5@mail.com','0933333335','gvbm');

-- STUDENTS = 5
INSERT INTO students (user_id,dob,gender,address)
SELECT user_id,'2010-01-01','Male','HCM City'
FROM users WHERE role_id='student';

-- GRADE LEVELS
INSERT INTO grade_levels (grade_name) VALUES
('Grade 6'),('Grade 7'),('Grade 8');

-- CLASSES
INSERT INTO classes (class_name,grade_id) VALUES
('6A1',1),('6A2',1),
('7A1',2),('7A2',2),
('8A1',3);

-- ACADEMIC YEARS
INSERT INTO academic_years (name,start_date,end_date) VALUES
('2024-2025','2025-09-01','2026-05-31');

-- SEMESTERS
INSERT INTO semesters (year_id,name,start_date,end_date) VALUES
(1,'HK1','2025-09-01','2026-12-31'),
(1,'HK2','2026-05-01','2026-08-31');

-- SUBJECTS
INSERT INTO subjects(name) VALUES
('Math'),('Physics'),('Chemistry'),('English'),('History');

-- TEACHER ASSIGNMENTS
INSERT INTO teacher_assignments(teacher_id,subject_id,class_id,semester_id,periods) VALUES
(11,1,1,1,4),
(12,2,1,1,3),
(13,3,2,1,2),
(14,4,2,1,3),
(15,5,3,1,2);

-- TIMETABLE
INSERT INTO timetable(class_id,subject_id,teacher_id,semester_id,day,period,room) VALUES
(1,1,11,1,'Mon',1,'A1'),
(1,2,12,1,'Tue',2,'A1'),
(2,3,13,1,'Wed',3,'A2');

-- TUITION
INSERT INTO tuition(student_id,description,name,amount,semester_id,due_date,status) VALUES
(1,'Học phí HK1','Tuition HK1',2000000,1,'2024-10-01','unpaid'),
(2,'Học phí HK1','Tuition HK1',2000000,1,'2024-10-01','paid');

-- STUDENT EVALUATIONS
INSERT INTO student_evaluations(student_id,class_id,semester_id,conduct,teacher_comment) VALUES
(1,1,1,'Tốt','Chăm ngoan'),
(2,1,1,'Khá','Tiến bộ');

-- STUDENT CLASS
INSERT INTO student_class(student_id,class_id,school_year_id) VALUES
(1,1,1),(2,1,1),(3,2,1),(4,2,1),(5,3,1);

-- SCORES
INSERT INTO scores(student_id,assign_id,score_type,score_value) VALUES
(1,1,'oral',9),
(1,1,'quiz15',8),
(1,1,'final',9.5);

-- SCHOOL INFO
INSERT INTO school_info(school_name,address,phone) VALUES
('Trường THCS ABC','HCM City','0900009999');

-- NOTIFICATIONS
INSERT INTO notifications(sender_id,target_role,title,message) VALUES
(1,'all','Thông báo khai giảng','Ngày khai giảng 5/9');

-- HOMEROOM ASSIGNMENTS
INSERT INTO homeroom_assignments(class_id,teacher_id,year_id,assigned_date) VALUES
(1,11,1,'2024-08-20');

-- GRADE RANK
INSERT INTO grade_rank(rank_name,min_score,max_score) VALUES
('Giỏi',8.0,10.0),
('Khá',6.5,7.9),
('Trung Bình',5.0,6.4),
('Yếu',0,4.9);

-- COMMENTS
INSERT INTO comments(student_id,teacher_id,semester_id,comment_text) VALUES
(1,11,1,'Tiếp tục phát huy.');


ALTER TABLE student_class
DROP FOREIGN KEY student_class_ibfk_1;

ALTER TABLE student_class
ADD CONSTRAINT student_class_ibfk_1
FOREIGN KEY (student_id)
REFERENCES students(student_id)
ON DELETE CASCADE;


ALTER TABLE teacher_assignments
DROP FOREIGN KEY teacher_assignments_ibfk_1;

ALTER TABLE teacher_assignments
ADD CONSTRAINT teacher_assignments_ibfk_1
FOREIGN KEY (teacher_id)
REFERENCES users(user_id)
ON DELETE CASCADE;


CREATE TABLE IF NOT EXISTS parents (
    parent_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT UNIQUE NOT NULL,
    job VARCHAR(100),
    FOREIGN KEY(user_id) REFERENCES users(user_id) ON DELETE CASCADE
);




CREATE TABLE IF NOT EXISTS student_parent (
    id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,
    parent_id INT NOT NULL,
    relation VARCHAR(50), 
    FOREIGN KEY (student_id) REFERENCES students(student_id) ON DELETE CASCADE,
    FOREIGN KEY (parent_id) REFERENCES parents(parent_id) ON DELETE CASCADE
);

INSERT INTO users (username, password, fullname, email, phone, role_id, created_at) VALUES
('parent1', '123', 'Nguyen Van A (PH HS1)', 'parent1@example.com', '0912345678', 'parent', NOW()),
('parent2', '123', 'Tran Thi B (PH HS2)', 'parent2@example.com', '0987654321', 'parent', NOW()),
('parent3', '123', 'Le Van C (PH HS3)', 'parent3@example.com', '0901122334', 'parent', NOW());

-- 4. Thêm dữ liệu vào bảng Parents
-- Lấy user_id 21, 22, 23 vừa tạo ở bước 3 để nạp vào
INSERT INTO parents (user_id, job) VALUES 
(21, 'Kỹ sư'),    -- Sẽ sinh ra parent_id = 1
(22, 'Bác sĩ'),    -- Sẽ sinh ra parent_id = 2
(23, 'Giáo viên'); -- Sẽ sinh ra parent_id = 3

-- 5. Thêm mối quan hệ vào student_parent
-- Dùng parent_id 1, 2, 3 (không phải 13, 14, 15)
INSERT INTO student_parent (student_id, parent_id, relation) VALUES
(1, 1, 'Cha'),  -- Học sinh 1 là con của Parent 1 (user 21)
(2, 2, 'Mẹ'),   -- Học sinh 2 là con của Parent 2 (user 22)
(3, 3, 'Cha');  -- Học sinh 3 là con của Parent 3 (user 23)


USE school_management_c;



-- =================================================================================

-- PHẦN 1: CODE CỦA BẠN (Dữ liệu Phụ huynh, Điểm cụ thể, Học phí)

-- =================================================================================



-- 1.1. THÊM TÀI KHOẢN USER CHO CÁC PHỤ HUYNH

INSERT INTO users (username, password, fullname, email, phone, role_id) VALUES

('parent1_mom', '123', 'Tran Thi Me (PH HS1)', 'mom1@mail.com', '0911110001', 'parent'),

('parent2_dad', '123', 'Le Van Cha (PH HS2)', 'dad2@mail.com', '0911110002', 'parent'),

('parent3_mom', '123', 'Nguyen Thi Me (PH HS3)', 'mom3@mail.com', '0911110003', 'parent'),

('parent4_dad', '123', 'Hoang Van Cha (PH HS4)', 'dad4@mail.com', '0911110004', 'parent'),

('parent4_mom', '123', 'Pham Thi Me (PH HS4)', 'mom4@mail.com', '0911110005', 'parent'),

('parent5_dad', '123', 'Vo Van Cha (PH HS5)', 'dad5@mail.com', '0911110006', 'parent'),

('parent5_mom', '123', 'Dang Thi Me (PH HS5)', 'mom5@mail.com', '0911110007', 'parent');



-- 1.2. THÊM DỮ LIỆU VÀO BẢNG PARENTS

INSERT INTO parents (user_id, job) VALUES

((SELECT user_id FROM users WHERE username='parent1_mom'), 'Kế toán'),

((SELECT user_id FROM users WHERE username='parent2_dad'), 'Kiến trúc sư'),

((SELECT user_id FROM users WHERE username='parent3_mom'), 'Y tá'),

((SELECT user_id FROM users WHERE username='parent4_dad'), 'Công an'),

((SELECT user_id FROM users WHERE username='parent4_mom'), 'Nội trợ'),

((SELECT user_id FROM users WHERE username='parent5_dad'), 'Nông dân'),

((SELECT user_id FROM users WHERE username='parent5_mom'), 'Tiểu thương');



-- 1.3. LIÊN KẾT PHỤ HUYNH VỚI HỌC SINH

INSERT INTO student_parent (student_id, parent_id, relation) VALUES

(1, (SELECT parent_id FROM parents WHERE user_id = (SELECT user_id FROM users WHERE username='parent1_mom')), 'Mẹ'),

(2, (SELECT parent_id FROM parents WHERE user_id = (SELECT user_id FROM users WHERE username='parent2_dad')), 'Cha'),

(3, (SELECT parent_id FROM parents WHERE user_id = (SELECT user_id FROM users WHERE username='parent3_mom')), 'Mẹ'),

(4, (SELECT parent_id FROM parents WHERE user_id = (SELECT user_id FROM users WHERE username='parent4_dad')), 'Cha'),

(4, (SELECT parent_id FROM parents WHERE user_id = (SELECT user_id FROM users WHERE username='parent4_mom')), 'Mẹ'),

(5, (SELECT parent_id FROM parents WHERE user_id = (SELECT user_id FROM users WHERE username='parent5_dad')), 'Cha'),

(5, (SELECT parent_id FROM parents WHERE user_id = (SELECT user_id FROM users WHERE username='parent5_mom')), 'Mẹ');



-- 1.4. THÊM ĐIỂM SỐ CỤ THỂ (CODE CỦA BẠN)

INSERT INTO scores (student_id, assign_id, score_type, score_value) VALUES

-- HS1 (Lớp 6A1)

(1, 2, 'oral', 8.0), (1, 2, 'quiz15', 7.5), (1, 2, 'midterm', 8.0), (1, 2, 'final', 8.5),

-- HS2 (Lớp 6A1)

(2, 1, 'oral', 6.0), (2, 1, 'quiz15', 5.0), (2, 1, 'midterm', 6.5), (2, 1, 'final', 7.0),

(2, 2, 'oral', 9.0), (2, 2, 'quiz15', 9.5), (2, 2, 'midterm', 9.0), (2, 2, 'final', 9.5),

-- HS3, HS4, HS5 (Các lớp khác)

(3, 3, 'oral', 7.0), (3, 3, 'quiz15', 7.5), (3, 3, 'midterm', 8.0),

(3, 4, 'oral', 5.0), (3, 4, 'quiz15', 4.5), (3, 4, 'midterm', 5.0), (3, 4, 'final', 6.0),

(4, 3, 'oral', 9.5), (4, 3, 'quiz15', 10.0), (4, 3, 'midterm', 9.5), (4, 3, 'final', 10.0),

(4, 4, 'oral', 8.0), (4, 4, 'quiz15', 8.0), (4, 4, 'midterm', 8.5), (4, 4, 'final', 9.0),

(5, 5, 'oral', 8.0), (5, 5, 'quiz15', 8.5), (5, 5, 'midterm', 8.0), (5, 5, 'final', 9.0);



-- 1.5. HỌC PHÍ & HẠNH KIỂM (CODE CỦA BẠN)

INSERT INTO tuition (student_id, description, name, amount, semester_id, due_date, status) VALUES

(3, 'Học phí HK1', 'Tuition HK1', 2000000, 1, '2024-10-01', 'unpaid'),

(4, 'Học phí HK1', 'Tuition HK1', 2000000, 1, '2024-10-01', 'paid'),

(5, 'Học phí HK1', 'Tuition HK1', 2500000, 1, '2024-10-01', 'unpaid');



INSERT INTO student_evaluations (student_id, class_id, semester_id, conduct, teacher_comment) VALUES

(3, 2, 1, 'Trung Bình', 'Cần tập trung hơn trong giờ học'),

(4, 2, 1, 'Tốt', 'Học giỏi, hay giúp đỡ bạn bè'),

(5, 3, 1, 'Khá', 'Có tiến bộ so với năm ngoái');



-- =================================================================================

-- PHẦN 2: BỔ SUNG DATA CHO LỚP 6A1 (ĐỂ TEST GVCN1 VÀ STUDENT1 FULL)

-- =================================================================================



-- 2.1. TẠO THÊM 3 HỌC SINH MỚI (Student 6, 7, 8)

INSERT INTO users (username, password, fullname, email, phone, role_id) VALUES 

('student6', '123', 'Nguyen Van F', 'st6@mail.com', '0911111116', 'student'),

('student7', '123', 'Tran Thi G', 'st7@mail.com', '0911111117', 'student'),

('student8', '123', 'Le Van H', 'st8@mail.com', '0911111118', 'student');



INSERT INTO students (user_id, dob, gender, address) 

SELECT user_id, '2010-05-20', 'Male', 'Ha Noi' FROM users WHERE username = 'student6'

UNION ALL

SELECT user_id, '2010-08-15', 'Female', 'Da Nang' FROM users WHERE username = 'student7'

UNION ALL

SELECT user_id, '2010-12-01', 'Male', 'TP.HCM' FROM users WHERE username = 'student8';



-- 2.2. XẾP 3 HỌC SINH MỚI VÀO LỚP 6A1 (Class ID = 1)

INSERT INTO student_class (student_id, class_id, school_year_id)

SELECT student_id, 1, 1 

FROM students 

WHERE user_id IN (SELECT user_id FROM users WHERE username IN ('student6', 'student7', 'student8'));



-- 2.3. PHÂN CÔNG GIÁO VIÊN CÁC MÔN CÒN THIẾU CHO LỚP 6A1

-- Lớp 6A1 mới có Math, Physics. Cần thêm Chemistry, English, History.

INSERT INTO teacher_assignments (teacher_id, subject_id, class_id, semester_id, periods) VALUES

(13, 3, 1, 1, 2), -- GVBM3 dạy Hóa

(14, 4, 1, 1, 3), -- GVBM4 dạy Anh

(15, 5, 1, 1, 2); -- GVBM5 dạy Sử



-- =================================================================================

-- PHẦN 3: TỰ ĐỘNG ĐIỀN ĐIỂM (AUTO FILL)

-- =================================================================================

-- Mục tiêu: Đảm bảo Student 1, 2 (cũ) và 6, 7, 8 (mới) đều có đủ điểm 5 môn.

-- Logic: Chỉ thêm điểm nếu chưa có (để không ghi đè điểm bạn đã nhập tay ở Phần 1).



-- 3.1. Điểm Miệng (Oral)

INSERT INTO scores (student_id, assign_id, score_type, score_value)

SELECT s.student_id, ta.assign_id, 'oral', FLOOR(7 + (RAND() * 3))

FROM student_class s

JOIN teacher_assignments ta ON s.class_id = ta.class_id

WHERE s.class_id = 1 

AND NOT EXISTS (SELECT 1 FROM scores sc WHERE sc.student_id = s.student_id AND sc.assign_id = ta.assign_id AND sc.score_type = 'oral');



-- 3.2. Điểm 15 Phút (quiz15)

INSERT INTO scores (student_id, assign_id, score_type, score_value)

SELECT s.student_id, ta.assign_id, 'quiz15', FLOOR(6 + (RAND() * 4))

FROM student_class s

JOIN teacher_assignments ta ON s.class_id = ta.class_id

WHERE s.class_id = 1

AND NOT EXISTS (SELECT 1 FROM scores sc WHERE sc.student_id = s.student_id AND sc.assign_id = ta.assign_id AND sc.score_type = 'quiz15');



-- 3.3. Điểm Giữa Kỳ / 1 Tiết (midterm)

INSERT INTO scores (student_id, assign_id, score_type, score_value)

SELECT s.student_id, ta.assign_id, 'midterm', FLOOR(5 + (RAND() * 5))

FROM student_class s

JOIN teacher_assignments ta ON s.class_id = ta.class_id

WHERE s.class_id = 1

AND NOT EXISTS (SELECT 1 FROM scores sc WHERE sc.student_id = s.student_id AND sc.assign_id = ta.assign_id AND sc.score_type = 'midterm');



-- 3.4. Điểm Cuối Kỳ (final)

INSERT INTO scores (student_id, assign_id, score_type, score_value)

SELECT s.student_id, ta.assign_id, 'final', FLOOR(5 + (RAND() * 5))

FROM student_class s

JOIN teacher_assignments ta ON s.class_id = ta.class_id

WHERE s.class_id = 1

AND NOT EXISTS (SELECT 1 FROM scores sc WHERE sc.student_id = s.student_id AND sc.assign_id = ta.assign_id AND sc.score_type = 'final');





USE school_management_c;



-- =================================================================================

-- PHẦN 4: BỔ SUNG PHỤ HUYNH CHO HỌC SINH MỚI (STUDENT 6, 7, 8)

-- =================================================================================



-- 4.1. Tạo tài khoản User cho phụ huynh của Student 6, 7, 8

INSERT INTO users (username, password, fullname, email, phone, role_id) VALUES 

('parent6_dad', '123', 'Nguyen Van Cha F (PH HS6)', 'dad6@mail.com', '0911110008', 'parent'),

('parent7_mom', '123', 'Tran Thi Me G (PH HS7)', 'mom7@mail.com', '0911110009', 'parent'),

('parent8_dad', '123', 'Le Van Cha H (PH HS8)', 'dad8@mail.com', '0911110010', 'parent');



-- 4.2. Thêm thông tin nghề nghiệp vào bảng Parents

INSERT INTO parents (user_id, job) VALUES 

((SELECT user_id FROM users WHERE username='parent6_dad'), 'Kỹ sư phần mềm'),

((SELECT user_id FROM users WHERE username='parent7_mom'), 'Dược sĩ'),

((SELECT user_id FROM users WHERE username='parent8_dad'), 'Luật sư');



-- 4.3. Liên kết Phụ huynh với Học sinh (Bảng student_parent)

INSERT INTO student_parent (student_id, parent_id, relation) VALUES

-- Liên kết Student 6 với Parent 6

(

    (SELECT student_id FROM students WHERE user_id = (SELECT user_id FROM users WHERE username='student6')),

    (SELECT parent_id FROM parents WHERE user_id = (SELECT user_id FROM users WHERE username='parent6_dad')),

    'Cha'

),

-- Liên kết Student 7 với Parent 7

(

    (SELECT student_id FROM students WHERE user_id = (SELECT user_id FROM users WHERE username='student7')),

    (SELECT parent_id FROM parents WHERE user_id = (SELECT user_id FROM users WHERE username='parent7_mom')),

    'Mẹ'

),

-- Liên kết Student 8 với Parent 8

(

    (SELECT student_id FROM students WHERE user_id = (SELECT user_id FROM users WHERE username='student8')),

    (SELECT parent_id FROM parents WHERE user_id = (SELECT user_id FROM users WHERE username='parent8_dad')),

    'Cha'

);



INSERT INTO users (username, password, fullname, email, phone, role_id) VALUES 

('parent6_mom', '123', 'Nguyen Thi Me F (PH HS6)', 'mom6@mail.com', '0911110011', 'parent'),

('parent7_dad', '123', 'Tran Van Cha G (PH HS7)', 'dad7@mail.com', '0911110012', 'parent'),

('parent8_mom', '123', 'Le Thi Me H (PH HS8)', 'mom8@mail.com', '0911110013', 'parent');



-- 5.2. Thêm thông tin nghề nghiệp vào bảng Parents

INSERT INTO parents (user_id, job) VALUES 

((SELECT user_id FROM users WHERE username='parent6_mom'), 'Giáo viên'),

((SELECT user_id FROM users WHERE username='parent7_dad'), 'Kiến trúc sư'),

((SELECT user_id FROM users WHERE username='parent8_mom'), 'Bác sĩ nha khoa');



-- 5.3. Liên kết vào bảng student_parent

INSERT INTO student_parent (student_id, parent_id, relation) VALUES

-- Thêm Mẹ cho Student 6

(

    (SELECT student_id FROM students WHERE user_id = (SELECT user_id FROM users WHERE username='student6')),

    (SELECT parent_id FROM parents WHERE user_id = (SELECT user_id FROM users WHERE username='parent6_mom')),

    'Mẹ'

),

-- Thêm Cha cho Student 7

(

    (SELECT student_id FROM students WHERE user_id = (SELECT user_id FROM users WHERE username='student7')),

    (SELECT parent_id FROM parents WHERE user_id = (SELECT user_id FROM users WHERE username='parent7_dad')),

    'Cha'

),

-- Thêm Mẹ cho Student 8

(

    (SELECT student_id FROM students WHERE user_id = (SELECT user_id FROM users WHERE username='student8')),

    (SELECT parent_id FROM parents WHERE user_id = (SELECT user_id FROM users WHERE username='parent8_mom')),

    'Mẹ'

);



-- =================================================================================

-- KIỂM TRA LẠI DỮ LIỆU

-- =================================================================================

-- Chạy câu lệnh này để xem danh sách học sinh kèm tên Cha Mẹ

SELECT 

    s.student_id,

    u_st.fullname AS Student_Name,

    MAX(CASE WHEN sp.relation = 'Cha' THEN u_pa.fullname END) AS Father_Name,

    MAX(CASE WHEN sp.relation = 'Mẹ' THEN u_pa.fullname END) AS Mother_Name

FROM students s

JOIN users u_st ON s.user_id = u_st.user_id

LEFT JOIN student_parent sp ON s.student_id = sp.student_id

LEFT JOIN parents p ON sp.parent_id = p.parent_id

LEFT JOIN users u_pa ON p.user_id = u_pa.user_id

GROUP BY s.student_id, u_st.fullname;


USE school_management_c;

-- =================================================================================
-- PHẦN 6: TẠO THỜI KHÓA BIỂU CHI TIẾT (Cho Lớp 6A1 - Student 1)
-- =================================================================================

-- 6.1. Bổ sung môn "Sinh hoạt lớp" (SHL) để xếp vào tiết cuối tuần cho GVCN
INSERT INTO subjects (name) VALUES ('Sinh hoạt lớp');

-- 6.2. Đảm bảo phân công chuyên môn đầy đủ cho lớp 6A1
-- (Trước đó ta mới chỉ assign Math, Physics cho Class 1. Giờ assign thêm để xếp TKB không bị lỗi logic)
INSERT INTO teacher_assignments (teacher_id, subject_id, class_id, semester_id, periods) VALUES
(13, 3, 1, 1, 2), -- GVBM3 dạy Hóa cho 6A1
(14, 4, 1, 1, 3), -- GVBM4 dạy Anh cho 6A1
(15, 5, 1, 1, 2), -- GVBM5 dạy Sử cho 6A1
(11, (SELECT subject_id FROM subjects WHERE name='Sinh hoạt lớp'), 1, 1, 1); -- GVCN1 dạy SHL

-- 6.3. Xóa TKB cũ của lớp 6A1 (nếu có) để tránh trùng lặp
DELETE FROM timetable WHERE class_id = 1 AND semester_id = 1;

-- 6.4. CHÈN DỮ LIỆU THỜI KHÓA BIỂU (Full tuần cho Student 1)
-- Giả định: 
-- Class ID = 1 (6A1)
-- Semester ID = 1 (HK1)
-- Teacher 11 (Math/GVCN), 12 (Lý), 13 (Hóa), 14 (Anh), 15 (Sử)

INSERT INTO timetable (class_id, semester_id, day, period, subject_id, teacher_id, room) VALUES
-- THỨ 2 (Chào cờ, Toán, Toán, Anh, Anh)
(1, 1, 'Mon', 1, (SELECT subject_id FROM subjects WHERE name='Math'), 11, 'P.101'),
(1, 1, 'Mon', 2, (SELECT subject_id FROM subjects WHERE name='Math'), 11, 'P.101'),
(1, 1, 'Mon', 3, (SELECT subject_id FROM subjects WHERE name='English'), 14, 'P.101'),
(1, 1, 'Mon', 4, (SELECT subject_id FROM subjects WHERE name='English'), 14, 'P.101'),

-- THỨ 3 (Lý, Lý, Sử, Hóa)
(1, 1, 'Tue', 1, (SELECT subject_id FROM subjects WHERE name='Physics'), 12, 'Lab 1'),
(1, 1, 'Tue', 2, (SELECT subject_id FROM subjects WHERE name='Physics'), 12, 'Lab 1'),
(1, 1, 'Tue', 3, (SELECT subject_id FROM subjects WHERE name='History'), 15, 'P.101'),
(1, 1, 'Tue', 4, (SELECT subject_id FROM subjects WHERE name='Chemistry'), 13, 'Lab 2'),

-- THỨ 4 (Toán, Toán, Anh, Sử)
(1, 1, 'Wed', 1, (SELECT subject_id FROM subjects WHERE name='Math'), 11, 'P.101'),
(1, 1, 'Wed', 2, (SELECT subject_id FROM subjects WHERE name='Math'), 11, 'P.101'),
(1, 1, 'Wed', 3, (SELECT subject_id FROM subjects WHERE name='English'), 14, 'P.101'),
(1, 1, 'Wed', 4, (SELECT subject_id FROM subjects WHERE name='History'), 15, 'P.101'),

-- THỨ 5 (Hóa, Hóa, Lý, Tự học)
(1, 1, 'Thu', 1, (SELECT subject_id FROM subjects WHERE name='Chemistry'), 13, 'Lab 2'),
(1, 1, 'Thu', 2, (SELECT subject_id FROM subjects WHERE name='Chemistry'), 13, 'Lab 2'),
(1, 1, 'Thu', 3, (SELECT subject_id FROM subjects WHERE name='Physics'), 12, 'Lab 1'),
-- Tiết 4 trống

-- THỨ 6 (Toán, Sử, Anh, Sinh Hoạt Lớp)
(1, 1, 'Fri', 1, (SELECT subject_id FROM subjects WHERE name='Math'), 11, 'P.101'),
(1, 1, 'Fri', 2, (SELECT subject_id FROM subjects WHERE name='History'), 15, 'P.101'),
(1, 1, 'Fri', 3, (SELECT subject_id FROM subjects WHERE name='English'), 14, 'P.101'),
(1, 1, 'Fri', 4, (SELECT subject_id FROM subjects WHERE name='Sinh hoạt lớp'), 11, 'P.101');


-- =================================================================================
-- QUERY KIỂM TRA (TEST)
-- =================================================================================

-- 1. Xem TKB của Student 1 (Theo lớp 6A1)
SELECT 
    t.day AS Thu,
    t.period AS Tiet,
    s.name AS Mon_Hoc,
    u.fullname AS Giao_Vien,
    t.room AS Phong
FROM timetable t
JOIN subjects s ON t.subject_id = s.subject_id
JOIN users u ON t.teacher_id = u.user_id
WHERE t.class_id = 1 
ORDER BY FIELD(t.day, 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'), t.period;

-- 2. Xem TKB của GVCN (Teacher ID 11 - Dạy Toán và SHL)
SELECT 
    t.day AS Thu,
    t.period AS Tiet,
    c.class_name AS Lop_Day,
    s.name AS Mon_Day,
    t.room AS Phong
FROM timetable t
JOIN classes c ON t.class_id = c.class_id
JOIN subjects s ON t.subject_id = s.subject_id
WHERE t.teacher_id = 11
ORDER BY FIELD(t.day, 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'), t.period;

USE school_management_c;

-- =================================================================================
-- KHẮC PHỤC LỖI 1175: TẮT CHẾ ĐỘ SAFE UPDATE
-- =================================================================================
SET SQL_SAFE_UPDATES = 0;

-- =================================================================================
-- BƯỚC 0: DỌN DẸP DỮ LIỆU CŨ/LỖI (TỪ STUDENT 9 TRỞ ĐI)
-- =================================================================================
-- Xóa bảng liên kết phụ huynh
DELETE FROM student_parent 
WHERE student_id IN (SELECT student_id FROM students WHERE user_id IN (SELECT user_id FROM users WHERE username REGEXP '^student(9|1[0-8])$'));

-- Xóa bảng điểm
DELETE FROM scores 
WHERE student_id IN (SELECT student_id FROM students WHERE user_id IN (SELECT user_id FROM users WHERE username REGEXP '^student(9|1[0-8])$'));

-- Xóa bảng học phí (Đây là chỗ bị lỗi lúc nãy)
DELETE FROM tuition 
WHERE student_id IN (SELECT student_id FROM students WHERE user_id IN (SELECT user_id FROM users WHERE username REGEXP '^student(9|1[0-8])$'));

-- Xóa bảng phân lớp
DELETE FROM student_class 
WHERE student_id IN (SELECT student_id FROM students WHERE user_id IN (SELECT user_id FROM users WHERE username REGEXP '^student(9|1[0-8])$'));

-- Xóa phụ huynh (Xóa theo user_id để tránh lỗi ràng buộc khóa ngoại)
DELETE FROM parents 
WHERE user_id IN (SELECT user_id FROM users WHERE username REGEXP '^parent(9|1[0-8])_');

-- Xóa học sinh
DELETE FROM students 
WHERE user_id IN (SELECT user_id FROM users WHERE username REGEXP '^student(9|1[0-8])$');

-- Cuối cùng là xóa tài khoản Users
DELETE FROM users WHERE username REGEXP '^student(9|1[0-8])$';
DELETE FROM users WHERE username REGEXP '^parent(9|1[0-8])_';


-- =================================================================================
-- PHẦN 7: THÊM 7 HỌC SINH MỚI (STUDENT 9 -> 15) CHO LỚP 6A1
-- =================================================================================

-- 7.1. Tạo User cho 7 học sinh
INSERT INTO users (username, password, fullname, email, phone, role_id) VALUES
('student9', '123', 'Pham Van I', 'st9@mail.com', '0911111119', 'student'),
('student10', '123', 'Do Thi K', 'st10@mail.com', '0911111120', 'student'),
('student11', '123', 'Hoang Van L', 'st11@mail.com', '0911111121', 'student'),
('student12', '123', 'Ngo Thi M', 'st12@mail.com', '0911111122', 'student'),
('student13', '123', 'Vu Van N', 'st13@mail.com', '0911111123', 'student'),
('student14', '123', 'Duong Thi O', 'st14@mail.com', '0911111124', 'student'),
('student15', '123', 'Ly Van P', 'st15@mail.com', '0911111125', 'student');

-- 7.2. Tạo thông tin chi tiết (Students table)
INSERT INTO students (user_id, dob, gender, address)
SELECT user_id, '2010-02-10', 'Male', 'Quan 1, HCM' FROM users WHERE username = 'student9' UNION ALL
SELECT user_id, '2010-03-15', 'Female', 'Quan 3, HCM' FROM users WHERE username = 'student10' UNION ALL
SELECT user_id, '2010-04-20', 'Male', 'Thu Duc, HCM' FROM users WHERE username = 'student11' UNION ALL
SELECT user_id, '2010-05-25', 'Female', 'Binh Thanh, HCM' FROM users WHERE username = 'student12' UNION ALL
SELECT user_id, '2010-06-30', 'Male', 'Go Vap, HCM' FROM users WHERE username = 'student13' UNION ALL
SELECT user_id, '2010-07-05', 'Female', 'Tan Binh, HCM' FROM users WHERE username = 'student14' UNION ALL
SELECT user_id, '2010-08-10', 'Male', 'Phu Nhuan, HCM' FROM users WHERE username = 'student15';

-- 7.3. Xếp 7 học sinh này vào lớp 6A1 (Class ID = 1)
INSERT INTO student_class (student_id, class_id, school_year_id)
SELECT student_id, 1, 1 
FROM students 
WHERE user_id IN (SELECT user_id FROM users WHERE username REGEXP '^student(9|1[0-5])$');


-- =================================================================================
-- PHẦN 8: THÊM PHỤ HUYNH CHO 7 HỌC SINH NÀY
-- =================================================================================

-- 8.1. Tạo User Phụ huynh (7 Cha, 7 Mẹ)
INSERT INTO users (username, password, fullname, email, phone, role_id) VALUES
-- Parent HS 9
('parent9_dad', '123', 'Cha HS 9', 'dad9@mail.com', '0999000009', 'parent'),
('parent9_mom', '123', 'Me HS 9', 'mom9@mail.com', '0999111009', 'parent'),
-- Parent HS 10
('parent10_dad', '123', 'Cha HS 10', 'dad10@mail.com', '0999000010', 'parent'),
('parent10_mom', '123', 'Me HS 10', 'mom10@mail.com', '0999111010', 'parent'),
-- Parent HS 11
('parent11_dad', '123', 'Cha HS 11', 'dad11@mail.com', '0999000011', 'parent'),
('parent11_mom', '123', 'Me HS 11', 'mom11@mail.com', '0999111011', 'parent'),
-- Parent HS 12
('parent12_dad', '123', 'Cha HS 12', 'dad12@mail.com', '0999000012', 'parent'),
('parent12_mom', '123', 'Me HS 12', 'mom12@mail.com', '0999111012', 'parent'),
-- Parent HS 13
('parent13_dad', '123', 'Cha HS 13', 'dad13@mail.com', '0999000013', 'parent'),
('parent13_mom', '123', 'Me HS 13', 'mom13@mail.com', '0999111013', 'parent'),
-- Parent HS 14
('parent14_dad', '123', 'Cha HS 14', 'dad14@mail.com', '0999000014', 'parent'),
('parent14_mom', '123', 'Me HS 14', 'mom14@mail.com', '0999111014', 'parent'),
-- Parent HS 15
('parent15_dad', '123', 'Cha HS 15', 'dad15@mail.com', '0999000015', 'parent'),
('parent15_mom', '123', 'Me HS 15', 'mom15@mail.com', '0999111015', 'parent');

-- 8.2. Thêm vào bảng Parents (Chỉ lấy đúng những user vừa tạo)
INSERT INTO parents (user_id, job)
SELECT user_id, 'Phụ huynh tự do'
FROM users 
WHERE username IN (
    'parent9_dad', 'parent9_mom',
    'parent10_dad', 'parent10_mom',
    'parent11_dad', 'parent11_mom',
    'parent12_dad', 'parent12_mom',
    'parent13_dad', 'parent13_mom',
    'parent14_dad', 'parent14_mom',
    'parent15_dad', 'parent15_mom'
);

-- 8.3. Liên kết Student - Parent
INSERT INTO student_parent (student_id, parent_id, relation)
SELECT 
    s.student_id, 
    p.parent_id,
    CASE WHEN u_p.username LIKE '%_dad' THEN 'Cha' ELSE 'Mẹ' END
FROM students s
JOIN users u_s ON s.user_id = u_s.user_id
JOIN users u_p ON u_p.username LIKE CONCAT(u_s.username, '_%')
JOIN parents p ON p.user_id = u_p.user_id
WHERE u_s.username REGEXP '^student(9|1[0-5])$';


-- =================================================================================
-- PHẦN 9: SINH ĐIỂM VÀ HỌC PHÍ
-- =================================================================================

-- 9.1. Điểm (Oral, Quiz15, Midterm, Final)
INSERT INTO scores (student_id, assign_id, score_type, score_value)
SELECT s.student_id, ta.assign_id, 'oral', ROUND(6 + (RAND() * 4), 1)
FROM student_class s JOIN teacher_assignments ta ON s.class_id = ta.class_id
WHERE s.class_id = 1 AND s.student_id NOT IN (SELECT student_id FROM scores WHERE score_type='oral');

INSERT INTO scores (student_id, assign_id, score_type, score_value)
SELECT s.student_id, ta.assign_id, 'quiz15', ROUND(5 + (RAND() * 5), 1)
FROM student_class s JOIN teacher_assignments ta ON s.class_id = ta.class_id
WHERE s.class_id = 1 AND s.student_id NOT IN (SELECT student_id FROM scores WHERE score_type='quiz15');

INSERT INTO scores (student_id, assign_id, score_type, score_value)
SELECT s.student_id, ta.assign_id, 'midterm', ROUND(5 + (RAND() * 5), 1)
FROM student_class s JOIN teacher_assignments ta ON s.class_id = ta.class_id
WHERE s.class_id = 1 AND s.student_id NOT IN (SELECT student_id FROM scores WHERE score_type='midterm');

INSERT INTO scores (student_id, assign_id, score_type, score_value)
SELECT s.student_id, ta.assign_id, 'final', ROUND(5 + (RAND() * 5), 1)
FROM student_class s JOIN teacher_assignments ta ON s.class_id = ta.class_id
WHERE s.class_id = 1 AND s.student_id NOT IN (SELECT student_id FROM scores WHERE score_type='final');

-- 9.2. Học phí
INSERT INTO tuition (student_id, description, name, amount, semester_id, due_date, status)
SELECT s.student_id, 'Học phí HK1', 'Tuition HK1', 2000000, 1, '2024-10-01', 'unpaid'
FROM students s JOIN users u ON s.user_id = u.user_id
WHERE u.username REGEXP '^student(9|1[0-5])$';

-- =================================================================================
-- BẬT LẠI CHẾ ĐỘ SAFE UPDATE (QUAN TRỌNG ĐỂ BẢO VỆ DB SAU NÀY)
-- =================================================================================
SET SQL_SAFE_UPDATES = 1;

-- =================================================================================
-- KIỂM TRA LẠI
-- =================================================================================
SELECT 
    s.student_id,
    u_st.fullname AS Hoc_Sinh,
    MAX(CASE WHEN sp.relation = 'Cha' THEN u_pa.fullname END) AS Cha,
    MAX(CASE WHEN sp.relation = 'Mẹ' THEN u_pa.fullname END) AS Me
FROM students s
JOIN users u_st ON s.user_id = u_st.user_id
LEFT JOIN student_parent sp ON s.student_id = sp.student_id
LEFT JOIN parents p ON sp.parent_id = p.parent_id
LEFT JOIN users u_pa ON p.user_id = u_pa.user_id
WHERE u_st.username REGEXP '^student(9|1[0-5])$'
GROUP BY s.student_id, u_st.fullname;

USE school_management_c;

-- =================================================================================
-- BỔ SUNG PHỤ HUYNH CHO HỌC SINH TỪ 9 ĐẾN 15 (CHẠY RỜI)
-- =================================================================================

-- BƯỚC 1: TẠO TÀI KHOẢN USER CHO 14 PHỤ HUYNH (7 CHA, 7 MẸ)
-- Dùng INSERT IGNORE để nếu lỡ có user nào trùng thì bỏ qua, không báo lỗi đỏ
INSERT IGNORE INTO users (username, password, fullname, email, phone, role_id) VALUES
-- Parent HS 9
('parent9_dad', '123', 'Cha HS 9', 'dad9@mail.com', '0999000009', 'parent'),
('parent9_mom', '123', 'Me HS 9', 'mom9@mail.com', '0999111009', 'parent'),
-- Parent HS 10
('parent10_dad', '123', 'Cha HS 10', 'dad10@mail.com', '0999000010', 'parent'),
('parent10_mom', '123', 'Me HS 10', 'mom10@mail.com', '0999111010', 'parent'),
-- Parent HS 11
('parent11_dad', '123', 'Cha HS 11', 'dad11@mail.com', '0999000011', 'parent'),
('parent11_mom', '123', 'Me HS 11', 'mom11@mail.com', '0999111011', 'parent'),
-- Parent HS 12
('parent12_dad', '123', 'Cha HS 12', 'dad12@mail.com', '0999000012', 'parent'),
('parent12_mom', '123', 'Me HS 12', 'mom12@mail.com', '0999111012', 'parent'),
-- Parent HS 13
('parent13_dad', '123', 'Cha HS 13', 'dad13@mail.com', '0999000013', 'parent'),
('parent13_mom', '123', 'Me HS 13', 'mom13@mail.com', '0999111013', 'parent'),
-- Parent HS 14
('parent14_dad', '123', 'Cha HS 14', 'dad14@mail.com', '0999000014', 'parent'),
('parent14_mom', '123', 'Me HS 14', 'mom14@mail.com', '0999111014', 'parent'),
-- Parent HS 15
('parent15_dad', '123', 'Cha HS 15', 'dad15@mail.com', '0999000015', 'parent'),
('parent15_mom', '123', 'Me HS 15', 'mom15@mail.com', '0999111015', 'parent');

-- BƯỚC 2: TẠO PROFILE TRONG BẢNG PARENTS
-- Chỉ lấy những user có tên 'parent9...' -> 'parent15...' và chưa có trong bảng parents
INSERT INTO parents (user_id, job)
SELECT user_id, 'Phụ huynh (Bổ sung)'
FROM users 
WHERE username REGEXP '^parent(9|1[0-5])_(dad|mom)$'
AND user_id NOT IN (SELECT user_id FROM parents);

-- BƯỚC 3: LIÊN KẾT HỌC SINH VỚI PHỤ HUYNH
-- Tự động ghép: student9 sẽ nhận parent9_dad và parent9_mom làm cha mẹ
INSERT INTO student_parent (student_id, parent_id, relation)
SELECT 
    s.student_id, 
    p.parent_id,
    CASE WHEN u_p.username LIKE '%_dad' THEN 'Cha' ELSE 'Mẹ' END
FROM students s
JOIN users u_s ON s.user_id = u_s.user_id
-- Kỹ thuật nối chuỗi: tìm user phụ huynh có tên bắt đầu bằng tên học sinh + dấu gạch dưới
-- Ví dụ: student9 sẽ khớp với parent9_dad
JOIN users u_p ON u_p.username LIKE CONCAT(REPLACE(u_s.username, 'student', 'parent'), '_%')
JOIN parents p ON p.user_id = u_p.user_id
WHERE u_s.username REGEXP '^student(9|1[0-5])$'
-- Dòng này để đảm bảo không insert trùng nếu đã có liên kết rồi
AND NOT EXISTS (
    SELECT 1 FROM student_parent sp 
    WHERE sp.student_id = s.student_id AND sp.parent_id = p.parent_id
);

-- =================================================================================
-- KIỂM TRA LẠI KẾT QUẢ
-- =================================================================================
SELECT 
    u_st.username AS Tai_Khoan_HS,
    u_st.fullname AS Ten_Hoc_Sinh,
    MAX(CASE WHEN sp.relation = 'Cha' THEN u_pa.fullname END) AS Ten_Cha,
    MAX(CASE WHEN sp.relation = 'Mẹ' THEN u_pa.fullname END) AS Ten_Me
FROM students s
JOIN users u_st ON s.user_id = u_st.user_id
LEFT JOIN student_parent sp ON s.student_id = sp.student_id
LEFT JOIN parents p ON sp.parent_id = p.parent_id
LEFT JOIN users u_pa ON p.user_id = u_pa.user_id
WHERE u_st.username REGEXP '^student(9|1[0-5])$'
GROUP BY s.student_id, u_st.username, u_st.fullname;