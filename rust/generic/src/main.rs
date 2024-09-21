fn main() {
    println!("Hello, world from the project 'creatorly.project_name'!");
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn it_works() {
        assert_eq!(0, 0);
    }
}
