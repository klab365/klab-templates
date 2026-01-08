cmake_minimum_required(VERSION 3.23)

set(CMAKE_EXPORT_COMPILE_COMMANDS ON)

enable_testing()

# Coverage settings
if(CMAKE_CXX_COMPILER_ID MATCHES "GNU|Clang")
    set(COVERAGE_FLAGS "--coverage")
    set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} ${COVERAGE_FLAGS}")
    set(CMAKE_EXE_LINKER_FLAGS "${CMAKE_EXE_LINKER_FLAGS} ${COVERAGE_FLAGS}")
    set(CMAKE_SHARED_LINKER_FLAGS "${CMAKE_SHARED_LINKER_FLAGS} ${COVERAGE_FLAGS}")
endif()

add_subdirectory(src/core)
add_subdirectory(src/adapters)
add_subdirectory(src/cmd/console)
