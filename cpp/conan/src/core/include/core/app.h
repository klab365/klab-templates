#pragma once

#include <string>

namespace core {

class App {
   public:
    App();
    void run();
    std::string getVersion() const;

   private:
    std::string version_;
};

} 
