cmake_minimum_required(VERSION 3.15)
project(core LANGUAGES CXX)

add_library(core src/app.cpp)

target_include_directories(core
    PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/include
    PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/src
)

# Unit tests
find_package(GTest REQUIRED)

enable_testing()
add_executable(core_tests tests/test_app.cpp)
target_link_libraries(core_tests PRIVATE core GTest::gtest_main)
add_test(NAME core_tests COMMAND core_tests)
