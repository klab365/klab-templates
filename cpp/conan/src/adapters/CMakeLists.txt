cmake_minimum_required(VERSION 3.15)
project(adapters LANGUAGES CXX)

add_library(adapters src/adapter.cpp)

target_include_directories(adapters
    PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/include
    PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/src
)

