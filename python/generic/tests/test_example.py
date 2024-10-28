import creatorly_project_slug.hello_world as app


def test_it_works():
    app.say_hello()
    assert True


def test_it_fails():
    assert False
